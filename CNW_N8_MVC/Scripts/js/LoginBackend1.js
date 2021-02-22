$(document).ready(function () {
    $("#login").attr('type', 'button');
});

$("#login").click(function () {
    var user = $("#username").val();
    var pass = $("#password").val();

    $.ajax({
        method: "get",
        url: "/BackendHome/checkLoginBackend",
        data: { user: user, pass: pass }
    }).done(function (thongbao) {
        if (thongbao == -1) {
            $("#divThongBao").html("Tài Khoản hoặc Mật Khẩu Không Đúng hoặc User không có quyền truy cập !");
        }
        else {
            $("#login").attr('type', 'submit');
            $("#login").click();
        }
    });
})