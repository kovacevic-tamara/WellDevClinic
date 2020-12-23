﻿var allPrescriptions;

$(document).ready(function () {
	$.ajax({
		method: "GET",
		url: "../api/prescription/all",
		contentType: "application/json",
		success: function (data) {
			allPrescriptions = data;
			$(".loader").css("display", "none");
			viewAllPrescriptions(allPrescriptions);
		},
	});

	$(".btnFilter").click(function () {
		$("#divFilterTable").slideToggle();
	})
});

function viewAllPrescriptions(prescriptions) {
	$("#viewPrescription").empty();
	for (let pre of prescriptions) {
		var content = '<div class="card" id="' + pre.id + '">';
		content += '<div class="card-body">';
		content += '<div class="data">';
		content += '<table style="margin:10px">';
		content += '<tr><td float="right">Id:</td><td>';
		content += pre.id;
		content += '</td></tr>';
		content += '<tr><td>Patient:</td>';
		content += '<td>' + pre.patFirstName + ' ' + pre.patLastName + '</td></tr>';
		content += '<tr><td float="right">Start date:</td><td>';
		content += ISOtoShort(new Date(pre.timePeriod.startDate));
		content += '</td></tr>';
		content += '<tr><td float="right">End date:</td><td>';
		content += ISOtoShort(new Date(pre.timePeriod.endDate));
		content += '</td></tr>';
		if (pre.medication != null) {
			content += '<tr><td float="right">Prescription medicines:</td>';
			content += '<td>';
			for (let med of pre.medication)
				content += med.name + '<br/>';
			content += '</td>';
		}
		content += '</tr>';
		content += '<tr><td colspan="2">';

		generateQR(pre);
		content += '<img src="images/qrCodes/pre' + pre.id + 'qr.png" style="width:170px"/>';
		content += '</td></tr>';
		content += '<tr></tr>';
		content += '<tr><td colspan="2">'
		content += '<button type="button" class="btn btn-info" onclick="sendToPharmacies(\'' + pre.id + '\')" id="' + pre.id + '" data-toggle="modal" data-target="#exampleModalCenter1">';
		content += 'Send it to pharmacy</button > ';
		content += '</td><td>';
		content += '<button type="button" class="btn btn-light" style="font-size:22px;color:red" onclick="generatePDF(' + pre.id + ')"><i class="fa fa-file-pdf-o"></i></button>';
		content += '</td></tr> ';
		content += '</table>';
		content += '</div></div></div>';
		content += '</div>';
		$("#viewPrescription").append(content);
	}
}

function sortData() {
	let sort = $("#sort").val();
	let order = $("#order").val();
	sortCards(sort, order);
	viewAllPrescriptions(allPrescriptions);
}

// Dates are in format : yyyy-MM-dd so we can compare them as strings
function sortCards(sort, order) {
	for (let i = 0; i < (allPrescriptions.length - 1); i++) {
		let minIdx = i;
		for (let j = i + 1; j < allPrescriptions.length; j++) {
			if (sort == "patName") {
				if (allPrescriptions[minIdx].PatFirstName.toLowerCase() > allPrescriptions[j].PatFirstName.toLowerCase())
					minIdx = j;
			} else if (sort == "start") {
				if (allPrescriptions[minIdx].timePeriod.startDate > allPrescriptions[j].timePeriod.startDate)
					minIdx = j;
			} else if (sort == "expire") {
				if (allPrescriptions[minIdx].timePeriod.endDate > allPrescriptions[j].timePeriod.endDate)
					minIdx = j;
			} else if (sort == "list") {
				if (allPrescriptions[minIdx].id > allPrescriptions[j].id)
					minIdx = j;
			}
		}
		let temp = allPrescriptions[i];
		allPrescriptions[i] = allPrescriptions[minIdx];
		allPrescriptions[minIdx] = temp;
	}
	if (order == 'desc')
		allPrescriptions.reverse();
}

function filter() {
	filtered = [];
	let startDate = $("#start").val();
	let endDate = $("#end").val();

	if (startDate != "" && endDate != "" && startDate > endDate) {
		alert("Start date can't be greater than end date!")
		return;
	}

	for (let pre of allPrescriptions) {
		if (startDate && pre.timePeriod.startDate < startDate)
			continue;
		if (endDate && pre.timePeriod.endDate > endDate)
			continue;
		filtered.push(pre);
	}
	viewAllPrescriptions(filtered);
}

function sendToPharmacies(id) {
	$.ajax({
		method: "GET",
		url: "../api/prescription/" + id,
		contentType: "application/json",
		success: function (pre) {
			console.log(pre);
			$.ajax({
				method: "POST",
				url: "../api/sftp/sendPrescription",
				contentType: "application/json",
				data: JSON.stringify({
					PatientName: pre.patFirstName + " " + pre.patLastName,
					Jmbg: pre.patJmbg,
					StartTime: pre.timePeriod.startDate,
					EndTime: pre.timePeriod.endDate,
					Medicines: []
				}),
				success: function () {
					$("#sendMessage").text(" File is succesfully sent. ");
					$("#sentAction").show();
				},
				error: function (e) {
					if (e.status == 503) {
						$("#sendMessage").text(e.responseText);
						$("#sentAction").show();
                    }
				}
			});
		},
	});
}

function ISOtoShort(date) {
	let day = date.getDate();
	let month = (date.getMonth() + 1);
	let year = date.getFullYear();

	if (day < 10)
		day = '0' + day;
	if (month < 10)
		month = '0' + month;

	return String(day + '-' + month + '-' + year);
}

function generatePDF(id) {
	alert(id);
}

function generateQR(pre) {
	$.ajax({
		url: 'images/qrCodes/pre' + pre.id + 'qr.png',
		type: 'HEAD',
		error: function () {
			$.ajax({
				method: "POST",
				url: "../api/qrcode/eprescription",
				dataType: "applocation/json",
				contentType: "application/json",
				data: JSON.stringify({
					Id: pre.id,
					TimePeriod: {
						StartDate: pre.timePeriod.startDate,
						EndDate: pre.timePeriod.endDate,
						Id: pre.timePeriod.id
					},
					Medication: [],				// TODO A2: stringify za lekove
					PatJmbg: pre.PatJmbg,
					PatFirstName: pre.PatFirtsName,
					PatLastName: pre.PatLastName,
                })
			});
		},
	});
}