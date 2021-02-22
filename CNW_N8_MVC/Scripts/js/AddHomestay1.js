$(document).ready(function () {
    $("#btnThem").attr('type', 'button');
})


$("#homestay_name").blur(function () {
    var homestay_name = $("#homestay_name").val();
    var location_id = $("#location_id").val();
    var price = $("#price").val();
    var sell_price = $("#sell_price").val();

    $.ajax({
        method: "post",
        url: "/BackendHomestay/checkAddHomeStay",
        data: {
            homestay_name: homestay_name, location_id: location_id, price: price, sell_price: sell_price
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("* Homestay này đã tồn tại *");
            $("#btnThem").attr('type', 'button');

        } else if (thongbao == -1) {
            $("#divThongBao").html("* Thiếu Thông Tin *");
            $("#btnThem").attr('type', 'button');
        }
        else {
            $("#divThongBao").html("");
            $("#btnThem").attr('type', 'submit');
        }
    });
})

$("#location_id").blur(function () {
    var homestay_name = $("#homestay_name").val();
    var location_id = $("#location_id").val();
    var price = $("#price").val();
    var sell_price = $("#sell_price").val();

    $.ajax({
        method: "post",
        url: "/BackendHomestay/checkAddHomeStay",
        data: {
            homestay_name: homestay_name, location_id: location_id, price: price, sell_price: sell_price
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("* Homestay này đã tồn tại *");
            $("#btnThem").attr('type', 'button');

        } else if (thongbao == -1) {
            $("#divThongBao").html("* Thiếu Thông Tin *");
            $("#btnThem").attr('type', 'button');
        }
        else {
            $("#divThongBao").html("");
            $("#btnThem").attr('type', 'submit');
        }
    });
})

$("#price").blur(function () {
    var homestay_name = $("#homestay_name").val();
    var location_id = $("#location_id").val();
    var sell_price = $("#sell_price").val();
    var price = $("#price").val();

    $.ajax({
        method: "post",
        url: "/BackendHomestay/checkAddHomeStay",
        data: {
            homestay_name: homestay_name, location_id: location_id, price: price, sell_price: sell_price
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("* Homestay này đã tồn tại *");
            $("#btnThem").attr('type', 'button');

        } else if (thongbao == -1) {
            $("#divThongBao").html("* Thiếu Thông Tin *");
            $("#btnThem").attr('type', 'button');
        }
        else {
            $("#divThongBao").html("");
            $("#btnThem").attr('type', 'submit');
        }
    });

})

$("#sell_price").blur(function () {
    var homestay_name = $("#homestay_name").val();
    var location_id = $("#location_id").val();
    var price = $("#price").val();
    var sell_price = $("#sell_price").val();

    $.ajax({
        method: "post",
        url: "/BackendHomestay/checkAddHomeStay",
        data: {
            homestay_name: homestay_name, location_id: location_id, price: price, sell_price: sell_price
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("* Homestay này đã tồn tại *");
            $("#btnThem").attr('type', 'button');

        } else if (thongbao == -1) {
            $("#divThongBao").html("* Thiếu Thông Tin *");
            $("#btnThem").attr('type', 'button');
        }
        else {
            $("#divThongBao").html("");
            $("#btnThem").attr('type', 'submit');
        }
    });
})