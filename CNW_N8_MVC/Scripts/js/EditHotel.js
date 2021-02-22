$(document).ready(function () {
    $("#btnThem").attr('type', 'button');
})

$("#hotel_namee").blur(function () {
    var location_id = $("#location_id").val();
    var hotel_name = $("#hotel_namee").val();
    var description = $("#description").val();
    var more_imformation = $("#more_imformation").val();
    var price = $("#price").val();
    var sell_price = $("#sell_price").val();

    $.ajax({
        method: "post",
        url: "/BackendHotel/checkEditHotel",
        data: {
            location_id: location_id, hotel_name: hotel_name, description: description, more_imformation: more_imformation,
            price: price, sell_price: sell_price
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("Tên khách sạn bị trùng");
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

$("#description").blur(function () {
    var location_id = $("#location_id").val();
    var hotel_name = $("#hotel_namee").val();
    var description = $("#description").val();
    var more_imformation = $("#more_imformation").val();
    var price = $("#price").val();
    var sell_price = $("#sell_price").val();

    $.ajax({
        method: "post",
        url: "/BackendHotel/checkEditHotel",
        data: {
            location_id: location_id, hotel_name: hotel_name, description: description, more_imformation: more_imformation,
            price: price, sell_price: sell_price
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("Tên khách sạn bị trùng");
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

$("#more_imformation").blur(function () {
    var location_id = $("#location_id").val();
    var hotel_name = $("#hotel_namee").val();
    var description = $("#description").val();
    var more_imformation = $("#more_imformation").val();
    var price = $("#price").val();
    var sell_price = $("#sell_price").val();

    $.ajax({
        method: "post",
        url: "/BackendHotel/checkEditHotel",
        data: {
            location_id: location_id, hotel_name: hotel_name, description: description, more_imformation: more_imformation,
            price: price, sell_price: sell_price
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("Tên khách sạn bị trùng");
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

$("#price").blur(function () {
    var location_id = $("#location_id").val();
    var hotel_name = $("#hotel_namee").val();
    var description = $("#description").val();
    var more_imformation = $("#more_imformation").val();
    var price = $("#price").val();
    var sell_price = $("#sell_price").val();

    $.ajax({
        method: "post",
        url: "/BackendHotel/checkEditHotel",
        data: {
            location_id: location_id, hotel_name: hotel_name, description: description, more_imformation: more_imformation,
            price: price, sell_price: sell_price
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("Tên khách sạn bị trùng");
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

$("#sell_price").blur(function () {
    var location_id = $("#location_id").val();
    var hotel_name = $("#hotel_namee").val();
    var description = $("#description").val();
    var more_imformation = $("#more_imformation").val();
    var price = $("#price").val();
    var sell_price = $("#sell_price").val();

    $.ajax({
        method: "post",
        url: "/BackendHotel/checkEditHotel",
        data: {
            location_id: location_id, hotel_name: hotel_name, description: description, more_imformation: more_imformation,
            price: price, sell_price: sell_price
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("Tên khách sạn bị trùng");
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

$("#location_id").blur(function () {
    var location_id = $("#location_id").val();
    var hotel_name = $("#hotel_namee").val();
    var description = $("#description").val();
    var more_imformation = $("#more_imformation").val();
    var price = $("#price").val();
    var sell_price = $("#sell_price").val();

    $.ajax({
        method: "post",
        url: "/BackendHotel/checkEditHotel",
        data: {
            location_id: location_id, hotel_name: hotel_name, description: description, more_imformation: more_imformation,
            price: price, sell_price: sell_price
        }
    }).done(function (thongbao) {
        if (thongbao == 0) {
            $("#divThongBao").html("Tên khách sạn bị trùng");
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