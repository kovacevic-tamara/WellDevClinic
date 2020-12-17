﻿$(document).ready(function () {
	$.ajax({
		method: "GET",
		url: "../api/actionsandbenefits/all",
		contentType: "application/json",
		success: function (data) {
			actions = data;
			viewActionsAndBenefits(actions)
		}
	});
})


function viewActionsAndBenefits(data) {
	$(".salesNotifications").empty();
	var num = 0;
	for (let act of data) {
		if (act.status != 0)
			continue;
		let content = '<div class="card text-center"><div class="card-body">';
		content += '<h5 class="card-title">';
		content += act.pharmacyName;
		content += '</h5>';
		content += '<p>' + act.messageAboutAction + '</p>';
		content += '<button class="btn btn-danger" data-toggle="modal" data-target="#deleteActionModal" ';
		content += ' onclick="deleteSale(' + act.id + ')"> Discard </button > ';
		content += '<button class="btn btn-success"';
		content += ' onclick="saveSale(' + act.id + ')"> Save </button > ';
		content += '</div></div>';
		content += '</div>';

		num += 1;

		$(".salesNotifications").append(content);
	}
	document.getElementById('num').innerHTML = num;
}

function saveSale(id) {

	$.ajax({
		method: "PUT",
		url: "../api/actionsandbenefits/status/" + id + "/1",
		contentType: "application/json",
		success: function () {
			window.location.reload();
		}
	});
}

function deleteSale(id) {
	$("#deleteAction").show();
	$("button#btnYes").click(function () {
		$.ajax({
			method: "DELETE",
			url: "../api/actionsandbenefits/delete/" + id,
			contentType: "application/json",
			success: function (data) {
				if (data) {
					alert("Successfully deleted");
					window.location.reload();
				}
			},
		});
	});
}