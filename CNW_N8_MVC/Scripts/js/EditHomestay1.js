$(document).ready(function () {
    $("#btnSua").attr('type', 'button');
})

$("#homestay_name").blur(function () {
    var homestay_name = $("#homestay_name").val();
    var location_id = $("#location_id").val();
    var price = $("#price").val();
    var sell_price = $("#sell_price").val();

    $.ajax({
        method: "post",
        url: "/BackendHomestay/checkEditHomestay",
        data: {
            homestay_name: homestay_name, location_id: location_id, price: price, sell_price: sell_price
        }
    }).done(function (thongbao) {
        if (thongbao == -1) {
            $("#divThongBao").html("* Homestay đã tồn tại Hoặc Thiếu thông tin *");
            $("#btnSua").attr('type', 'button');
        } else {
            $("#divThongBao").html("");
            $("#btnSua").attr('type', 'submit');
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
        url: "/BackendHomestay/checkEditHomestay",
        data: {
            homestay_name: homestay_name, location_id: location_id, price: price, sell_price: sell_price
        }
    }).done(function (thongbao) {
        if (thongbao == -1) {
            $("#divThongBao").html("* Homestay đã tồn tại Hoặc Thiếu thông tin *");
            $("#btnSua").attr('type', 'button');

        } else {
            $("#divThongBao").html("");
            $("#btnSua").attr('type', 'submit');
        }
    });
})

$("#price").blur(function () {
    var homestay_name = $("#homestay_name").val();
    var location_id = $("#location_id").val();
    var price = $("#price").val();
    var sell_price = $("#sell_price").val();

    $.ajax({
        method: "post",
        url: "/BackendHomestay/checkEditHomestay",
        data: {
            homestay_name: homestay_name, location_id: location_id, price: price, sell_price: sell_price
        }
    }).done(function (thongbao) {
        if (thongbao == -1) {
            $("#divThongBao").html("* Homestay đã tồn tại Hoặc Thiếu thông tin *");
            $("#btnSua").attr('type', 'button');

        } else {
            $("#divThongBao").html("");
            $("#btnSua").attr('type', 'submit');
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
        url: "/BackendHomestay/checkEditHomestay",
        data: {
            homestay_name: homestay_name, location_id: location_id, price: price, sell_price: sell_price
        }
    }).done(function (thongbao) {
        if (thongbao == -1) {
            $("#divThongBao").html("* Homestay đã tồn tại Hoặc Thiếu thông tin *");
            $("#btnSua").attr('type', 'button');

        } else {
            $("#divThongBao").html("");
            $("#btnSua").attr('type', 'submit');
        }
    });
})