

function setWidget(param, div) {
    var html="";
    $.ajax({
        type: "GET",
        url: "http://localhost:54059/place/GetDomainByName?file="+param,
        contentType: "application/json",
        dataType: "json",
        success: function (response) {
            console.log(response);
            WidgetCallback(response,param, div);
        },
        failure: function (response) {
            alert(response);
        },
    });
}

function update(param, div) {
   setWidget(param, div);
}

function WidgetCallback(JSONobject, param, div) {

    var wHTML = "";

    /*
     * Pending IE and Firefox
     *<script src="ie.js">
     *<![endif]-->
     *<!--[if !IE]><!-->
     *<script src="all.js"></script>
     *<!--<![endif]-->
     */
    wHTML += ('<meta name="viewport" content="width=device-width, initial-scale=1.0">');
    wHTML += ('<style>');
    wHTML += ('.a:hover {opacity: 1;}');
    wHTML += ('.nameResize{height: 4vw;}');
    wHTML += ('@media only screen and (max-width: 1250px)');
    wHTML += ('{');
    wHTML += ('    .nameResize{ height: 6vw;}');
    wHTML += ('}');
    wHTML += ('@media only screen and (max-width: 800px)');
    wHTML += ('{');
    wHTML += ('.nameResize{ height: 8vw;}');
    wHTML += ('}');
    wHTML += ('@media only screen and (max-width: 600px)');
    wHTML += ('{');
    wHTML += ('.nameResize{ height: 100%;}');
    wHTML += ('}');
    wHTML += ('</style>');
    

    wHTML += ('<div style="width: 300px; border: dotted">');
    wHTML += ('<div style="background: #00adf2; padding: 10px">');
    wHTML += ('<h3 style="display: contents;float: left">Hotels in ' + JSONobject.name + ' </h3>');
    wHTML += ('<a onclick=update("' + param + '","' + div +'")><span style="float: right; position: relative; padding-top: 6px" class="glyphicon glyphicon-refresh"></span></a>');
    wHTML += ('</div>');

    $.each(JSONobject.hotels, function (key, value) {
        wHTML += ('<div>');
        wHTML += ('<div style="padding: 10px;padding-bottom:0px;float: left">');
        wHTML += ('<img src="../../images/Hotels/' + value.image + '" />');
        wHTML += ('</div>');
        wHTML += ('<div style="display: inline;">');
        wHTML += ('<div class="nameResize" style="width:36%;padding-top: 10px;display: inline; float: left;">');
        wHTML += ('<p>' + value.name.substring(0,29) + '</p>');
        wHTML += ('</div>');
        wHTML += ('<div style="padding-top: 10px; display: inline; float: right;width: 26%">');


        $.each(new Array(value.starRating),
            function (n) { wHTML += ('<img src="images/star.png" />'); }
        );

        wHTML += ('</div>');
        wHTML += ('</div>');
        wHTML += ('<div style="display: -webkit-inline-box; width: 60%; padding-left: 26px;">');
        wHTML += ('<h4>From $'+ value.rate +'</h4>');
        wHTML += ('</div>');
  
        wHTML += ('</div>');
        wHTML += ('<hr style="margin:2%"> ');
       

    });

    wHTML += ('</div>');

    document.getElementById(div).innerHTML = wHTML;
    
}
