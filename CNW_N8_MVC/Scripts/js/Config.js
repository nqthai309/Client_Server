$(document).ready(function () {
    $("#saveChangePassword").attr('type', 'button');
});

$("#NewPassword2").blur(function () {
    var nowPassword = $("#nowPassword").val();
    var newPassword = $("#newPassword").val();
    var NewPassword2 = $("#NewPassword2").val();

    $.ajax({
        method: "get",
        url: "/User/checkNewPassword",
        data: { nowPassword: nowPassword, newPassword: newPassword, NewPassword2: NewPassword2}
    }).done(function (thongbao) {
        if (thongbao == 1) {
            $("#saveChangePassword").html("Save");
            $("#saveChangePassword").attr('type', 'submit');
            $("#divThongBao1").html("✔");
            $("#divThongBao2").html("");
        }
        else {
            $("#divThongBao2").html("Dữ liệu chưa chính xác !");
            $("#divThongBao1").html("");
            $("#saveChangePassword").attr('type', 'button');
        }
    });
});

$("#newPassword").blur(function () {
    var nowPassword = $("#nowPassword").val();
    var newPassword = $("#newPassword").val();
    var NewPassword2 = $("#NewPassword2").val();

    $.ajax({
        method: "get",
        url: "/User/checkNewPassword",
        data: { nowPassword: nowPassword, newPassword: newPassword, NewPassword2: NewPassword2 }
    }).done(function (thongbao) {
        if (thongbao == 1) {
            $("#saveChangePassword").html("Save");
            $("#saveChangePassword").attr('type', 'submit');
            $("#divThongBao1").html("✔");
            $("#divThongBao2").html("");
        }
        else {
            $("#divThongBao2").html("Dữ liệu chưa chính xác !");
            $("#divThongBao1").html("");
            $("#saveChangePassword").attr('type', 'button');
        }
    });
});

$("#nowPassword").blur(function () {
    var nowPassword = $("#nowPassword").val();
    var newPassword = $("#newPassword").val();
    var NewPassword2 = $("#NewPassword2").val();

    $.ajax({
        method: "get",
        url: "/User/checkNewPassword",
        data: { nowPassword: nowPassword, newPassword: newPassword, NewPassword2: NewPassword2 }
    }).done(function (thongbao) {
        if (thongbao == 1) {
            $("#saveChangePassword").html("Save");
            $("#saveChangePassword").attr('type', 'submit');
            $("#divThongBao1").html("✔");
            $("#divThongBao2").html("");
        }
        else {
            $("#divThongBao2").html("Dữ liệu chưa chính xác !");
            $("#divThongBao1").html("");
            $("#saveChangePassword").attr('type', 'button');
        }
    });
});