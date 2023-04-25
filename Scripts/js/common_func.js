
(function ($) {

	"use strict";

    var reservationDetails = {
        name: null,
        email: null,
        telefono: null,
        tableNumber: null,
        numberOfPeople: null,
        totalPrice: null,
        me_reference_id : null,
        selections: [
            {
                customer: 1,
                platillo: null,
                bebida: null
            },
            {
                customer: 2,
                platillo: null,
                bebida: null
            },
            {
                customer: 3,
                platillo: null,
                bebida: null
            },
            {
                customer: 4,
                platillo: null,
                bebida: null
            }
        ]
    }

	// Lazy load
	var lazyLoadInstance = new LazyLoad({
	    elements_selector: ".lazy"
	});

	// Header background
	$('.background-image').each(function(){
		$(this).css('background-image', $(this).attr('data-background'));
	});

	// Carousel categories home page
	var owlcat = $('.categories_carousel');
	owlcat.owlCarousel({
	    center: false,
	    stagePadding: 50,
	    items: 1,
	    loop: false,
	    margin: 20,
	    dots: false,
	    nav: true,
	    lazyLoad: true,
	    navText: ["<i class='arrow_left'></i>","<i class='arrow_right'></i>"],
	    responsive: {
	        0: {
	            nav: false,
	            dots: false,
	            items: 2
	        },
	        600: {
	            nav: false,
	            dots: false,
	            items: 2
	        },
	        768: {
	            nav: false,
	            dots: false,
	            items: 4
	        },
	        1025: {
	            nav: true,
	            dots: false,
	            items: 4
	        },
	        1340: {
	            nav: true,
	            dots: false,
	            items: 5
	        },
	        1460: {
	            nav: true,
	            dots: false,
	            items: 5
	        }
	    }
	});

	// Carousel home page
	var owl4 = $('.carousel_4');
		owl4.owlCarousel({
			items: 1,
			loop: false,
			stagePadding: 50,
			margin: 20,
			dots:false,
            lazyLoad:true,
			navText: ["<i class='arrow_left'></i>","<i class='arrow_right'></i>"],
			nav:false,
			responsive: {
			0: {
				items: 1
			},
			560: {
				items: 1
			},
			768: {
				items: 2
			},
			1230: {
				items: 3,
				nav: true
			}
		}
		});

	// Sticky nav
	$(window).on('scroll', function () {
		if ($(this).scrollTop() > 1) {
			$('.element_to_stick').addClass("sticky");
		} else {
			$('.element_to_stick').removeClass("sticky");
		}
	});
	$(window).scroll();
	
	// Menu
	$('a.open_close').on("click", function () {
		$('.main-menu').toggleClass('show');
		$('.layer').toggleClass('layer-is-visible');
	});
	$('a.show-submenu').on("click", function () {
		$(this).next().toggleClass("show_normal");
	});
	
	// Opacity mask
	$('.opacity-mask').each(function(){
		$(this).css('background-color', $(this).attr('data-opacity-mask'));
	});

	// Scroll to top
	var pxShow = 800; // height on which the button will show
	var scrollSpeed = 500; // how slow / fast you want the button to scroll to top.
	$(window).scroll(function(){
	 if($(window).scrollTop() >= pxShow){
		$("#toTop").addClass('visible');
	 } else {
		$("#toTop").removeClass('visible');
	 }
	});
	$('#toTop').on('click', function(){
	 $('html, body').animate({scrollTop:0}, scrollSpeed);
	 return false;
	});

	// Cart Dropdown Hidden From tablet
	$(window).bind('load resize', function () {
		var width = $(window).width();
		if (width <= 768) {
			$('a.cart_bt').removeAttr("data-bs-toggle", "dropdown")
		} else {
			$('a.cart_bt').attr("data-bs-toggle", "dropdown")
		}
	});
	
	// Footer collapse
	var $headingFooter = $('footer h3');
	$(window).resize(function() {
        if($(window).width() <= 768) {
      		$headingFooter.attr("data-bs-toggle","collapse");
        } else {
          $headingFooter.removeAttr("data-bs-toggle","collapse");
        }
    }).resize();
	$headingFooter.on("click", function () {
		$(this).toggleClass('opened');
	});

	// Scroll to position
    $('a[href^="#"].btn_scroll').on('click', function (e) {
			e.preventDefault();
			var target = this.hash;
			var $target = $(target);
			$('html, body').stop().animate({
				'scrollTop': $target.offset().top
			}, 800, 'swing', function () {
				window.location.hash = target;
			});
		});

	// Like Icon
    $('.btn_hero.wishlist').on('click', function(e){
    	e.preventDefault();
		$(this).toggleClass('liked');
	});

	// Modal Sign In
	$('#sign-in').magnificPopup({
		type: 'inline',
		fixedContentPos: true,
		fixedBgPos: true,
		overflowY: 'auto',
		closeBtnInside: true,
		preloader: false,
		midClick: true,
		removalDelay: 300,
		closeMarkup: '<button title="%title%" type="button" class="mfp-close"></button>',
		mainClass: 'my-mfp-zoom-in'
	});

	// Video modal
	$('.btn_play').magnificPopup({
		type: 'iframe',
		closeMarkup: '<button title="%title%" type="button" class="mfp-close" style="font-size:26px; margin-right:-10px;">&#215;</button>'
	});

	// Modal
	$('.modal_dialog').magnificPopup({
		type: 'inline',
		fixedContentPos: true,
		fixedBgPos: true,
		overflowY: 'auto',
		closeBtnInside: true,
		preloader: false,
		midClick: true,
		removalDelay: 300,
		closeMarkup: '<button title="%title%" type="button" class="mfp-close"></button>',
		mainClass: 'my-mfp-zoom-in'
	});

	// Modal images
	$('.magnific-gallery').each(function() {
	    $(this).magnificPopup({
	        delegate: 'a',
	        type: 'image',
	        preloader: true,
	        gallery: {
	            enabled: true
	        },
	        removalDelay: 500, //delay removal by X to allow out-animation
	        callbacks: {
	            beforeOpen: function() {
	                // just a hack that adds mfp-anim class to markup 
	                this.st.image.markup = this.st.image.markup.replace('mfp-figure', 'mfp-figure mfp-with-anim');
	                this.st.mainClass = this.st.el.attr('data-effect');
	            }
	        },
	        closeOnContentClick: true,
	        midClick: true // allow opening popup on middle mouse click. Always set it to true if you don't provide alternative source.
	    });
	});

	// Show hide password login modal and register page
	$('#password, #password1, #password2').hidePassword('focus', {
		toggle: {
			className: 'my-toggle'
		}
	});

	// Forgot Password
	$("#forgot").on('click', function () {
		$("#forgot_pw").fadeToggle("fast");
	});

	// Jquery select
	$('.custom_select select').niceSelect();

    function submit() {
        var data = {
            Id: $('#Id').val(),
            Name: $('#Name').val(),
            Addon: $('#Addon').is(':checked')
        };

        $.post("/Home/Form4", { sm: data }, function () { alert('Successfully Saved') });
    }

	// Accordion
	function toggleChevron(e) {
		$(e.target)
			.prev('.card-header')
			.find("i.indicator")
			.toggleClass('icon_minus-06 icon_plus');
	}
	$('.accordion_2').on('hidden.bs.collapse shown.bs.collapse', toggleChevron);
		function toggleIcon(e) {
        $(e.target)
            .prev('.panel-heading')
            .find(".indicator")
            .toggleClass('icon_minus-06 icon_plus');
        }



    $("#submit").click(function () {
        $("#overlay").show();
        const validateEmail = (email) => {
            return email.match(
                /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
            );
        };

        const validateTel = (tel) => {
            return tel.match(
                /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/
            );
        };

        const email = $('#email').val();
        const tel = $('#tel').val();

        if (!validateEmail(email)) {
            $("#invalidEmail").show();
        }
        if (!validateTel(tel)) {
            $("#invalidTel").show();
        }

        if (validateEmail(email) && validateTel(tel))
        {
            $.ajax({
                url: "/Cuponera/Validate",
                type: "post",
                data: {
                    'email': email,
                    'tel': tel,
                    'url': window.location.href
                },
                dataType: "json",
            }).done(function (result) {
                if (result.isSuccess) {
                    if (window.location.href.indexOf("TacosP11") >= 0) {
                        window.location.href = window.location.origin + "/TacosP11/Validated";
                    }
                    else if (window.location.href.indexOf("CaramelCoffe") >= 0) {
                        window.location.href = window.location.origin + "/CaramelCoffee/Validated";
                    }
                    else if (window.location.href.indexOf("JimJim") >= 0) {
                        window.location.href = window.location.origin + "/JimJim/Validated";
                    }
                    else if (window.location.href.indexOf("LaCapitalMX") >= 0 || window.location.href.indexOf("LaCapitalMx") >= 0 ) {
                        window.location.href = window.location.origin + "/LaCapitalMX/Validated";
                    }
                    else if (window.location.href.indexOf("LosJemos") >= 0) {
                        window.location.href = window.location.origin + "/LosJemos/Validated";
                    }
                    else if (window.location.href.indexOf("MrBeef") >= 0) {
                        window.location.href = window.location.origin + "/MrBeef/Validated";
                    }
                    else if (window.location.href.indexOf("Stevenson") >= 0) {
                        window.location.href = window.location.origin + "/Stevenson/Validated";
                    } else if (window.location.href.indexOf("TheBBQBros") >= 0) {
                        window.location.href = window.location.origin + "/TheBBQBros/Validated";
                    }
                    else {

                        window.location.href = window.location.origin + "/Cuponera/Validated";
                    }
                    $("#overlay").hide();
                }
            });
        }
        

    });

    function bindClicks() {
        $('#email').on('keypress', function () {
            $("#invalidEmail").hide();
        });

        $('#tel').on('keypress', function () {
            $("#invalidTel").hide();
        });

        $('#name').on('keypress', function () {
            $("#invalidName").hide();
        });
    }

    bindClicks();

    $(".status-free, .status-normal").click(function () {
        $("#overlay").show();
        var text = (this).innerText;
        if (text != "Sta" && text != "ge") {
            $(".status-payment").removeClass("status-payment");
            //$(".table").parent().addClass("status-normal");
            //$(".table").parent().removeClass("status-free");
            $(this).addClass("status-payment")
            $("#bookingDetails").show();
            reservationDetails.tableNumber = $(this).attr("id");
            $.ajax({
                url: "/Home/GetFormDetails",
                type: "get",
                data: {
                    'table': reservationDetails.tableNumber,
                },
            }).done(function (result) {
                $("#bookingDetails").html(result);
                bindNumberOfPeople();
                bindClicks();
                if (reservationDetails.name != null && reservationDetails.name != "") { $("#name").val(reservationDetails.name); }
                if (reservationDetails.email != null && reservationDetails.email != "") reservationDetails.email = $("#email").val(reservationDetails.email);
                if (reservationDetails.telefono != null && reservationDetails.telefono != "") reservationDetails.telefono = $("#tel").val(reservationDetails.telefono);
                $("#overlay").hide();

            }).fail(function (error) {
            }); 
        }
    });

    function bindNumberOfPeople() {
        $("#numberOfPeople").change(function () {
            $("#overlay").show();
            reservationDetails.name = $("#name").val();
            reservationDetails.email = $("#email").val();
            reservationDetails.telefono = $("#tel").val();
            reservationDetails.selections = [
                {
                    customer: 1,
                    platillo: null,
                    bebida: null
                },
                {
                    customer: 2,
                    platillo: null,
                    bebida: null
                },
                {
                    customer: 3,
                    platillo: null,
                    bebida: null
                },
                {
                    customer: 4,
                    platillo: null,
                    bebida: null
                }
            ]
            reservationDetails.numberOfPeople = $("#numberOfPeople").val();
            $.ajax({
                url: "/Home/GetDinnerDetails",
                type: "get",
                data: {
                    'numberOfPeople': reservationDetails.numberOfPeople,
                },
            }).done(function (result) {
                $("#dinnerDetails").html(result);
                bindSelectMenu();
                reservationDetails.totalPrice = $("#totalPrice").text().split(" ")[2];
                
                $("#overlay").hide();

            }).fail(function (error) {
            }); 
        });
    }

    function bindSelectMenu() {
        $(".platillo-selector").change(function () {
            var persona = $(this).attr("id").split("-")[1];
            var platillo = $(this).val();
            $($(".platillo-invalid-feedback")[persona-1]).hide()
            reservationDetails.selections[persona-1].platillo = platillo;
        });

        $(".bebida-selector").change(function () {
            var persona = $(this).attr("id").split("-")[1];
            var bebida = $(this).val();
            reservationDetails.selections[persona-1].bebida = bebida;
            $($(".bebida-invalid-feedback")[persona - 1]).hide()
        });

        $("#reservarBtn").click(function () {
            $("#overlay").show();
            var invalid = false;
            $(".platillo-invalid-feedback").hide();
            $(".bebida-invalid-feedback").hide();
            for (var i = 0; i < reservationDetails.numberOfPeople; i++)
            {
                if (reservationDetails.selections[i].platillo == null) {
                    invalid = true;
                    $($(".platillo-invalid-feedback")[i]).show();
                }
                if (reservationDetails.selections[i].bebida == null)
                {
                    invalid = true;
                    $($(".bebida-invalid-feedback")[i]).show();
                }
            }
            const validateEmail = (email) => {
                return email.match(
                    /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
                );
            };

            const validateTel = (tel) => {
                return tel.match(
                    /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/
                );
            };

            const email = $('#email').val();
            const tel = $('#tel').val();

            if (!validateEmail(email)) {
                $("#invalidEmail").show();
                invalid = true;
            }
            if (!validateTel(tel)) {
                $("#invalidTel").show();
                invalid = true;
            }

            if ($("#name").val() == "") {
                $("#invalidName").show();
                invalid = true;
            }

            if (!invalid) {

                reservationDetails.name = $("#name").val();
                reservationDetails.email = $("#email").val();
                reservationDetails.telefono = parseInt($("#tel").val());
                reservationDetails.totalPrice = parseInt($("#totalPrice").text().split(" ")[2]);
                
                $.ajax({
                    url: "/Home/RequestPayment",
                    type: "post",
                    data: reservationDetails,
                    dataType: "json",
                }).done(function (result) {
                    reservationDetails.me_reference_id = result.me_reference_id;
                    const options = {
                        method: 'POST',
                        headers: {
                            accept: 'application/vnd.com.payclip.v2+json',
                            'content-type': 'application/json',
                            'x-api-key': 'Basic M2VjNTQyMzgtMmE2Yi00MzA5LTk4NzYtMWUwMThkNjY5ZDNjOmVmMWFhNWE3LWU5ZDYtNDQ0Mi1iOWE0LTUxYWRlYTdjMjhjYg=='
                        },
                        body: JSON.stringify({
                            amount: reservationDetails.totalPrice,
                            //amount: 5,
                            currency: 'MXN',
                            purchase_description: 'Podcast en Vivo con Oxlack',
                            redirection_url: {
                                success: 'http://kitchenpark.com.mx/Home/success?me_reference_id=' + reservationDetails.me_reference_id,
                                error: 'http://kitchenpark.com.mx/Home/error?me_reference_id=' + reservationDetails.me_reference_id,
                                default: 'http://kitchenpark.com.mx/Home/Oxlack'
                            },
                            metadata: {
                                me_reference_id: reservationDetails.me_reference_id,
                                customer_info: { name: reservationDetails.name, email: reservationDetails.email, phone: reservationDetails.telefono  }
                            },
                            override_settings: {
                                payment_method: ['CARD'],
                                enable_tip: false,
                                currency: { show_currency_code: true }
                            },
                            webhook_url: 'https://hook.us1.make.com/k5f98kqxuuxgn4td6hgejrnu6lsi362p'
                        })
                    };

                    fetch('https://api-gw.payclip.com/checkout', options)
                        .then(
                            response => response.json()
                        )
                        .then(function (response) {
                            $.ajax({
                                url: "/Home/UpdateRequest",
                                type: "post",
                                data: {
                                    payment_request_id: response.payment_request_id,
                                    me_reference_id: reservationDetails.me_reference_id
                                },
                                dataType: "json",
                            }).done(function (result) {
                                if (result.success)
                                {
                                    window.location.href = response.payment_request_url;
                                }
                            });
                            
                        }
                        )
                        .catch(err => console.error(err));

                });

                
            }
            else {
                $("#overlay").hide();
            }
        });
    }

})(window.jQuery); 