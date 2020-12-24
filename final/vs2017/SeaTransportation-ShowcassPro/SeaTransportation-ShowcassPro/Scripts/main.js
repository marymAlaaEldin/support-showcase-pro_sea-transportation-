$(document).ready(function(){

    $("#baner").slideDown("slow");
    $(".profile-icon").click(function () {
        $("#profile").fadeIn();
        $(".cover").fadeIn();
    });

    $(".cover").click(function () {
        $("#profile").fadeOut();
        $(".cover").fadeOut();
    });
    $("#x").click(function () {
        $("#orderBox").fadeOut();
    });
    
    //$(".ship").rotate(30);
    //setTimeout(function () { $(".ship").rotate(30) }, 5)
    //$(".ship").css("-webkit-transform", "rotateY(90deg)");
    //$(".inner").fadeIn(1000);
    //$(".cont1").animate({
    //    marginTop:"10px"
    //},1000);
    //$(".cont2").animate({
    //    marginTop:"10px"
    //},1000);
    //$(".cont1").mouseenter(function(){
    //    $(this).children().animate({
    //        borderBottomLeftRadius: "0",
    //        borderBottomRightRadius: "0"
    //    },500);

    //  });
    //  $(".cont1").mouseleave(function(){
    //    $(this).children().animate({
    //        borderBottomLeftRadius: "150px",
    //        borderBottomRightRadius: "150px"
    //    },500);

    //  });
    //  $(".cont2").mouseenter(function(){
    //    $(this).children().animate({
    //        borderBottomLeftRadius:"0",
    //        borderBottomRightRadius: "0",
    //    }, 500);
    //    $(this).children().next().fadeOut(); 

    //  });
    //  $(".cont2").mouseleave(function(){
    //    $(this).children().animate({
    //        borderBottomLeftRadius: "150px",
    //        borderBottomRightRadius: "150px"
    //    },500);

    //  });
    
});
var $slide = $('.slide'),
    $slideGroup = $('.slide-group'),
    $bullet = $('.bullet');

var slidesTotal = ($slide.length - 1),
    current = 0,
    isAutoSliding = true;

$bullet.first().addClass('current');

var clickSlide = function() {
  window.clearInterval(autoSlide);
  isAutoSliding = false;

  var slideIndex = $bullet.index($(this));

  updateIndex(slideIndex);
};

var updateIndex = function(currentSlide) {
  if(isAutoSliding) {
    if(current === slidesTotal) {
      current = 0;
    } else {
      current++;
    }
  } else {
      current = currentSlide;
  }

  $bullet.removeClass('current');
  $bullet.eq(current).addClass('current');

  transition(current);
};

var transition = function(slidePosition) {
    $slideGroup.animate({
      'top': '-' + slidePosition + '00%'
    });
};

$bullet.on( 'click', clickSlide);

var autoSlide = window.setInterval(updateIndex, 2000);            
