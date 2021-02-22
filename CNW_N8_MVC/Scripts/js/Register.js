$(document).ready(function () {
    $("#register").attr('type', 'button');
});

$("#password").keyup(function () {
    
    var user = $("#username").val();
    var pass = $("#password").val();
    $.ajax({
        method: "get",
        url: "/User/checkDangKy",
        data: { user: user, pass: pass }
    }).done(function (thongbao) {
        if (thongbao == "0") {
            
            $("#register").attr('type', 'submit');
            $("#divThongBao1").html("Tai Khoan Co The Dang Ky !");
            $("#divThongBao2").html("");
            $("#register").html("Sign Up");
        }
        else {
            $("#divThongBao2").html("Thieu Thong tin hoac username bi trung !");
            $("#divThongBao1").html("");
        }
    });
});

$("#username").keyup(function () {

    var user = $("#username").val();
    var pass = $("#password").val();
    $.ajax({
        method: "get",
        url: "/User/checkDangKy",
        data: { user: user, pass: pass }
    }).done(function (thongbao) {
        if (thongbao == "0") {

            $("#register").attr('type', 'submit');
            $("#divThongBao1").html("Tài Khoản Có Thể Đăng Ký !");
            $("#divThongBao2").html("");
            $("#register").html("Sign Up");
        }
        else {
            $("#divThongBao2").html("Thiếu thông tin hoặc Username bị trùng !");
            $("#divThongBao1").html("");
        }
    });
});