$(document).ready(function () {

//---------------------Thumbnail images: change attr of "mainImage"----------------------------

    //when the image is clicked
    $('.imageView .imageTabs img').on('click', function () {
        //do this
        //set a variable to the src value
        var url = $(this).attr('src');
        //change the attr: src to the value url
        $('.imageView .mainImage img').attr('src', url);
       

//now, remove the class "active" from every image
        $('.imageView .imageTabs img').removeClass('active');
        //now, add the "active" class to only what was clicked
        $(this).addClass('active');

    });
    //--------------------Active Styling for the menu page----------------------------

    //add the active class to the menu page
    $('ul#menu li a').on('click', function () {
        //remove the class from everyone
       // $('ul#menu li').removeClass('active');
        //add the class to what was clicked
        $(this).addClass('active1');
    });
        
//------------------------Add To Cart functionality------------------------
    //this had better work

    $('.addToCart input').on('click', function () {
        
    });

});