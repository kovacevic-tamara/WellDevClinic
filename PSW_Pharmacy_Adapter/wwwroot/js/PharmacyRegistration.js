﻿$(document).ready(function () {
    let name = $("#TxtName").val();
    let url = $("#TxtUrl").val();
    let api = $("#TxtApi").val();

    let valid = true;

    if (!name) {
        valid = false;
    }
    if (!url) {
        valid = false;
    }
    if (!api) {
        valid = false;
    }

    if (valid) {
        var jsonApi = JSON.stringify({
            "NameOfHospital": name,
            "ApiKey": api,
            "Url": url
        });
    }

    $.ajax({
        method: "POST",
        url: "../api/APIKey/add",
        contentType: "application/json; charset=utf-8",
        data: jsonApi
    }).done(function (data) {
        if (data) {
            alert("Succesfully added to database");
        }
    });
})