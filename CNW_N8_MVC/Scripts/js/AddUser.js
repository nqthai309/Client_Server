$(document).ready(function () {
    $("#btnThem").attr('type', 'button');
})

$("#username").blur(function () {
    var username = $("#username").val();
    var password = $("#password").val();
    var email = $("#email").val();
    var phone = $("#phone").val();
    var address = $("#address").val();
    var full_name = $("#full_name").val();
    var role_id = $("#role_id").val();

    $.ajax({
        method: "post",
        url: "/BackendUser/checkAddUser",
        data: {
            username: username, password: password, email: email, phone: phone, address: address, full_name: full_name,
            role_id: role_id}
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("username đã có người sử dụng");
            $("#btnThem").attr('type', 'button');

        }else if (thongbao == -1) {
            $("#divThongBao").html("Thiếu Thông Tin");
            $("#btnThem").attr('type', 'button');
        }
        else {
            $("#divThongBao").html("");
            $("#btnThem").attr('type', 'submit');
        }
    });
})

$("#password").blur(function () {
    var username = $("#username").val();
    var password = $("#password").val();
    var email = $("#email").val();
    var phone = $("#phone").val();
    var address = $("#address").val();
    var full_name = $("#full_name").val();
    var role_id = $("#role_id").val();

    $.ajax({
        method: "post",
        url: "/BackendUser/checkAddUser",
        data: {
            username: username, password: password, email: email, phone: phone, address: address, full_name: full_name,
            role_id: role_id
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("username đã có người sử dụng");
            $("#btnThem").attr('type', 'button');

        } else if (thongbao == -1) {
            $("#divThongBao").html("Thiếu Thông Tin");
            $("#btnThem").attr('type', 'button');
        } else {
            $("#divThongBao").html("");
            $("#btnThem").attr('type', 'submit');
        }
    });
})

$("#email").blur(function () {
    var username = $("#username").val();
    var password = $("#password").val();
    var email = $("#email").val();
    var phone = $("#phone").val();
    var address = $("#address").val();
    var full_name = $("#full_name").val();
    var role_id = $("#role_id").val();

    $.ajax({
        method: "post",
        url: "/BackendUser/checkAddUser",
        data: {
            username: username, password: password, email: email, phone: phone, address: address, full_name: full_name,
            role_id: role_id
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("username đã có người sử dụng");
            $("#btnThem").attr('type', 'button');

        } else if (thongbao == -1) {
            $("#divThongBao").html("Thiếu Thông Tin");
            $("#btnThem").attr('type', 'button');
        } else {
            $("#divThongBao").html("");
            $("#btnThem").attr('type', 'submit');
        }
    });
})

$("#phone").blur(function () {
    var username = $("#username").val();
    var password = $("#password").val();
    var email = $("#email").val();
    var phone = $("#phone").val();
    var address = $("#address").val();
    var full_name = $("#full_name").val();
    var role_id = $("#role_id").val();

    $.ajax({
        method: "post",
        url: "/BackendUser/checkAddUser",
        data: {
            username: username, password: password, email: email, phone: phone, address: address, full_name: full_name,
            role_id: role_id
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("username đã có người sử dụng");
            $("#btnThem").attr('type', 'button');

        } else if (thongbao == -1) {
            $("#divThongBao").html("Thiếu Thông Tin");
            $("#btnThem").attr('type', 'button');
        } else {
            $("#divThongBao").html("");
            $("#btnThem").attr('type', 'submit');
        }
    });
})

$("#address").blur(function () {
    var username = $("#username").val();
    var password = $("#password").val();
    var email = $("#email").val();
    var phone = $("#phone").val();
    var address = $("#address").val();
    var full_name = $("#full_name").val();
    var role_id = $("#role_id").val();

    $.ajax({
        method: "post",
        url: "/BackendUser/checkAddUser",
        data: {
            username: username, password: password, email: email, phone: phone, address: address, full_name: full_name,
            role_id: role_id
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("username đã có người sử dụng");
            $("#btnThem").attr('type', 'button');

        } else if (thongbao == -1) {
            $("#divThongBao").html("Thiếu Thông Tin");
            $("#btnThem").attr('type', 'button');
        } else {
            $("#divThongBao").html("");
            $("#btnThem").attr('type', 'submit');
        }
    });
})

$("#full_name").blur(function () {
    var username = $("#username").val();
    var password = $("#password").val();
    var email = $("#email").val();
    var phone = $("#phone").val();
    var address = $("#address").val();
    var full_name = $("#full_name").val();
    var role_id = $("#role_id").val();

    $.ajax({
        method: "post",
        url: "/BackendUser/checkAddUser",
        data: {
            username: username, password: password, email: email, phone: phone, address: address, full_name: full_name,
            role_id: role_id
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("username đã có người sử dụng");
            $("#btnThem").attr('type', 'button');

        } else if (thongbao == -1) {
            $("#divThongBao").html("Thiếu Thông Tin");
            $("#btnThem").attr('type', 'button');
        } else {
            $("#divThongBao").html("");
            $("#btnThem").attr('type', 'submit');
        }
    });
})