$(document).ready(function () {
    var headerSlider = new Swiper('#home-slider', {
        // Optional parameters
        slidesPerView: 1,
        spaceBetween: 0,
        centeredSlides: true,
        loop: true,
        speed: 1500,
        parallax: true,
        autoplay: {
            delay: 5000,
        },
        effect: 'fade',
    });
    // var ticketSlider = new Swiper('#ticket-slider', {
    //     slidesPerView: 4,
    //     spaceBetween: 30,
    //     navigation: {
    //         nextEl: '.swiper-next',
    //         prevEl: '.swiper-prev',
    //     },
    // });
    document.querySelectorAll('.home-list-swiper').forEach(function (elem) {
        new Swiper(elem, {
            slidesPerView: 4,
            spaceBetween: 30,
            navigation: {
                nextEl: $(elem).children().next(),
                prevEl: $(elem).children().next().next(),
            }
        });
    });
    document.querySelectorAll('.accomodation-list-detail').forEach(function (elem) {
        new Swiper(elem, {
            slidesPerView: 4,
            spaceBetween: 30,
            navigation: {
                nextEl: $(elem).children().next(),
                prevEl: $(elem).children().next().next(),
            }
        });
    });

    var swiper = new Swiper('.swiper-slider-view', {
        slidesPerView: 1,
        spaceBetween: 30,
        loop: true,
        pagination: {
            el: '.swiper-pagination',
            clickable: true,
        },
        navigation: {
            nextEl: '.swiper-slider-next',
            prevEl: '.swiper-slider-prev',
        },
    });

    $('.sc-datepicker').datepicker({
        uiLibrary: 'materialdesign',
        icons: {
            rightIcon: '<i class="fas fa-calendar-alt color-main"></i>'
        }
    });
    $('#sidebar').stickySidebar({
        containerSelector: '#main-content',
        innerWrapperSelector: '.sidebar__inner',
        topSpacing: 100,
        bottomSpacing: 20
    });
    $('#slider').slider({
        slide: function (e, value) {
            document.getElementById('value').innerText = value;
        }
    });
    $('#slider_departure_time').slider({
        min: 0,
        max: 1439,
        slide: function (e, value) {
            var num = value;
            var hours = (num / 60);
            var rhours = Math.floor(hours);
            var minutes = (hours - rhours) * 60;
            var rminutes = Math.round(minutes);
            if (rhours < 10) {
                rhours = "0" + rhours;
            }
            if (rminutes < 10) {
                rminutes = "0" + rminutes;
            }
            value = rhours + ":" + rminutes;
            document.getElementById('value_departure_time').innerText = value;
        }
    });
    $('#slider_arrival_time').slider({
        min: 0,
        max: 1439,
        slide: function (e, value) {
            var num = value;
            var hours = (num / 60);
            var rhours = Math.floor(hours);
            var minutes = (hours - rhours) * 60;
            var rminutes = Math.round(minutes);
            if (rhours < 10) {
                rhours = "0" + rhours;
            }
            if (rminutes < 10) {
                rminutes = "0" + rminutes;
            }
            value = rhours + ":" + rminutes;
            document.getElementById('value_arrival_time').innerText = value;
        }
    });
    var slider = document.getElementById('noui-slider');
    noUiSlider.create(slider, {
        start: [0, 1000],
        connect: true,
        step: 1,

        tooltips: false,
        range: {
            'min': 0,
            'max': 1000
        }
    });
    slider.noUiSlider.on('update', function (values, handle) {
        document.getElementById('value').innerText = 'Từ ₭ ' + parseInt(values[0]) + ' đến ₭ ' + parseInt(values[1]);
    });
});

filterHighlight = function (e, is_selected) {
    console.log(e);
    $('.filter-accordion .panel-row').removeClass('panel-bg-red');
    $(e).find('.fas').removeClass('fas fa-chevron-up');
    $(e).find('.fas').addClass('fas fa-chevron-down');
    if (is_selected) {
        $(e).find('.panel-row').addClass('panel-bg-red');
        $(e).find('.fas').removeClass('fa-chevron-down');
        $(e).find('.fas').addClass('fa-chevron-up');
    }
}