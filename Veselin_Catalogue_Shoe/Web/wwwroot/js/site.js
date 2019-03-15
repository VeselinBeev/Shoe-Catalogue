// Write your JavaScript code.
$(".navbar .navbar-nav .nav-item").click(function () {
	$(this).addClass("active");
	if ($(this).hasClass("active")) {
		$(this).removeClass("active");
	}
});