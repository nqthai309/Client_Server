$(document).ready(function () {
    $("#datphong").attr('type', 'button');
});

$("#checkin").blur(function () {
    var checkin = $("#checkin").val();
    var checkout = $("#checkout").val();

    $.ajax({
        method: "get",
        url: "/Hotel/checkDate",
        data: { checkin: checkin, checkout: checkout }
    }).done(function (thongbao) {
        if (thongbao == 1) {;
            $("#divThongBao").html("");
            $("#datphong").attr('type', 'submit');
        }
        else {
            $("#divThongBao").html("Ngày Chưa Hợp Lệ !");
            $("#datphong").attr('type', 'button');
        }
    });
})

$("#checkout").blur(function () {
    var checkin = $("#checkin").val();
    var checkout = $("#checkout").val();

    $.ajax({
        method: "get",
        url: "/Hotel/checkDate",
        data: { checkin: checkin, checkout: checkout }
    }).done(function (thongbao) {
        if (thongbao == 1) {
            ;
            $("#divThongBao").html("");
            $("#datphong").attr('type', 'submit');
        }
        else {
            $("#divThongBao").html("Ngày Chưa Hợp Lệ !");
            $("#datphong").attr('type', 'button');
        }
    });
})