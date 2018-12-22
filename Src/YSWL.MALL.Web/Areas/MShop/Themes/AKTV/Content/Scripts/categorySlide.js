    $(function () {
        $("#cate").click(function () {
            $("body").addClass("bodyhtml");
            $("html").addClass("bodyhtml");
           // $("#category").addClass("category");
         //   $("#shop_page_contents").addClass("shop_page_contents");
            if (!$("#category").is(":animated")) {
              $("#category").animate({ left: "0%" }, 1000);
                 //  $("#category").addClass("category");
                $("#shop_page_contents").animate({ margin: "0px -60% 0px 60%" }, 1000);
            }
        });
//        $(".close").die("click").live("click", function () {
//            $("body").removeClass("bodyhtml");
//            $("html").removeClass("bodyhtml");
//           // if (!$("#category").is(":animated")) {
//                $("#category").animate({ left: "-100%" }, 500);
//                $("#shop_page_contents").animate({ margin: "0px" }, 1000);
//          // }
        //        });

        $('#category .close').click(function () {
            $('html, body').removeClass('bodyhtml');
            $('#cover_layer').hide();
            $('#category').animate({ left: '-100%' }, 500);
            $('#shop_page_contents').animate({ margin: '0' }, 500);
        });
    });



   