google.maps.event.addDomListener(window, 'load', init);

function init() {
    // Basic options for a simple Google Map
    // For more options see: https://developers.google.com/maps/documentation/javascript/reference#MapOptions
    
    var mapOptions = {
        // How zoomed in you want the map to start at (always required)
        zoom: 11,
        disableDefaultUI: false,
        // The latitude and longitude to center the map (always required)
        center: new google.maps.LatLng(_latitude, _longitude), // New York

        // How you would like to style the map.
        // This is where you would paste any style found on Snazzy Maps.
        styles: [{ "featureType": "administrative", "elementType": "labels.text.fill", "stylers": [{ "color": "#9b9b9b" }] }, { "featureType": "administrative", "elementType": "labels.text.stroke", "stylers": [{ "color": "#ffffff" }] }, { "featureType": "landscape", "elementType": "all", "stylers": [{ "hue": "#ffbf00" }, { "saturation": "-100" }, { "lightness": "27" }] }, { "featureType": "landscape", "elementType": "geometry.fill", "stylers": [{ "color": "#f0f0f0" }] }, { "featureType": "landscape.man_made", "elementType": "geometry.fill", "stylers": [{ "color": "#f0f0f0" }, { "visibility": "on" }] }, { "featureType": "landscape.man_made", "elementType": "geometry.stroke", "stylers": [{ "color": "#3d68eb" }, { "saturation": "-73" }, { "lightness": "71" }, { "visibility": "on" }] }, { "featureType": "poi", "elementType": "geometry.fill", "stylers": [{ "hue": "#00ff4e" }, { "saturation": "-30" }] }, { "featureType": "poi.attraction", "elementType": "geometry.fill", "stylers": [{ "hue": "#00fff1" }, { "saturation": "-39" }] }, { "featureType": "poi.attraction", "elementType": "labels", "stylers": [{ "hue": "#003fff" }] }, { "featureType": "poi.business", "elementType": "labels", "stylers": [{ "hue": "#003fff" }, { "saturation": "-50" }, { "lightness": "0" }] }, { "featureType": "poi.government", "elementType": "labels", "stylers": [{ "hue": "#003fff" }] }, { "featureType": "poi.medical", "elementType": "geometry.fill", "stylers": [{ "hue": "#0071ff" }] }, { "featureType": "poi.medical", "elementType": "labels", "stylers": [{ "hue": "#003fff" }, { "saturation": "-73" }] }, { "featureType": "poi.park", "elementType": "geometry.fill", "stylers": [{ "hue": "#00ff4e" }, { "saturation": "-30" }] }, { "featureType": "poi.park", "elementType": "labels.text", "stylers": [{ "visibility": "on" }, { "hue": "#00ff95" }, { "saturation": "-53" }] }, { "featureType": "poi.place_of_worship", "elementType": "geometry.fill", "stylers": [{ "hue": "#00ff4e" }] }, { "featureType": "poi.place_of_worship", "elementType": "labels", "stylers": [{ "hue": "#003fff" }] }, { "featureType": "poi.school", "elementType": "geometry.fill", "stylers": [{ "hue": "#ff0000" }, { "saturation": "-100" }, { "lightness": "12" }] }, { "featureType": "poi.school", "elementType": "labels", "stylers": [{ "hue": "#003fff" }] }, { "featureType": "poi.sports_complex", "elementType": "geometry.fill", "stylers": [{ "hue": "#00ff4e" }, { "saturation": "-30" }] }, { "featureType": "poi.sports_complex", "elementType": "labels", "stylers": [{ "hue": "#003fff" }] }, { "featureType": "road", "elementType": "labels.text.fill", "stylers": [{ "color": "#9b9b9b" }] }, { "featureType": "road", "elementType": "labels.icon", "stylers": [{ "hue": "#00a3ff" }] }, { "featureType": "road.highway", "elementType": "geometry.fill", "stylers": [{ "saturation": "17" }, { "lightness": "15" }, { "hue": "#0095ff" }] }, { "featureType": "road.highway", "elementType": "geometry.stroke", "stylers": [{ "hue": "#0095ff" }] }, { "featureType": "transit", "elementType": "labels", "stylers": [{ "hue": "#002bff" }, { "saturation": "-100" }, { "gamma": "1.00" }] }, { "featureType": "transit", "elementType": "labels.text.fill", "stylers": [{ "color": "#9b9b9b" }] }, { "featureType": "transit", "elementType": "labels.text.stroke", "stylers": [{ "color": "#ffffff" }] }, { "featureType": "water", "elementType": "geometry.fill", "stylers": [{ "color": "#98aef2" }] }, { "featureType": "water", "elementType": "labels.text", "stylers": [{ "hue": "#00b1ff" }, { "lightness": "33" }] }, { "featureType": "water", "elementType": "labels.text.fill", "stylers": [{ "color": "#233d8d" }] }]
    };

    // Get the HTML DOM element that will contain your map
    // We are using a div with id="map" seen below in the <body>
    var mapElement = document.getElementById('submit-map');

    // Create the Google Map using our element and options defined above
    var map = new google.maps.Map(mapElement, mapOptions);

    // Let's also add a marker while we're at it
    var marker = new google.maps.Marker({
        position: new google.maps.LatLng(_latitude, _longitude),
        map: map,
        title: 'Snazzy!',
        icon: '/assets/img/marker.png',
        labelAnchor: new google.maps.Point(50, 0),
        draggable: true
    });

    $('#submit-map').removeClass('fade-map');
    google.maps.event.addListener(marker, "mouseup", function (event) {
        var latitude = this.position.lat();
        var longitude = this.position.lng();
        $('#latitude').val(this.position.lat());
        $('#longitude').val(this.position.lng());
    });


    //      Autocomplete
    var input = (document.getElementById('address-map'));
    var autocomplete2 = new google.maps.places.Autocomplete(input);
    autocomplete2.bindTo('bounds', map);
    google.maps.event.addListener(autocomplete2, 'place_changed', function () {
        var place = autocomplete2.getPlace();
        if (!place.geometry) {
            return;
        }
        if (place.geometry.viewport) {
            map.fitBounds(place.geometry.viewport);
        } else {
            map.setCenter(place.geometry.location);
            map.setZoom(17);
        }
        marker.setPosition(place.geometry.location);
        marker.setVisible(true);
        $('#latitude').val(marker.getPosition().lat());
        $('#longitude').val(marker.getPosition().lng());
        var address = '';
        if (place.address_components) {
            address = [
                (place.address_components[0] && place.address_components[0].short_name || ''),
                (place.address_components[1] && place.address_components[1].short_name || ''),
                (place.address_components[2] && place.address_components[2].short_name || '')
            ].join(' ');
        }
    });
}
function success(position) {
    initSubmitMap(position.coords.latitude, position.coords.longitude);
    $('#latitude').val(position.coords.latitude);
    $('#longitude').val(position.coords.longitude);
}

$('.geo-location').on("click", function () {
    if (navigator.geolocation) {
        $('#submit-map').addClass('fade-map');
        navigator.geolocation.getCurrentPosition(success);
    } else {
        error('Geo Location is not supported');
    }
});




    // This example displays an address form, using the autocomplete feature
    // of the Google Places API to help users fill in the information.

    // This example requires the Places library. Include the libraries=places
    // parameter when you first load the API. For example:

//var placeSearch, autocomplete;
//var cityToBePosted;

//function initAutocomplete() {
//    // Create the autocomplete object, restricting the search to geographical
//    // location types.
//    autocomplete = new google.maps.places.Autocomplete(
//        (document.getElementById('autocomplete')),
//        { types: ['geocode'] });

//    // When the user selects an address from the dropdown, populate the address
//    // fields in the form.
//    autocomplete.addListener('place_changed', fillInAddress);
//}

//function fillInAddress() {
//    // Get the place details from the autocomplete object.
//    var place = autocomplete.getPlace();
//    document.getElementById("myTest").innerHTML = document.getElementById("autocomplete").value;
//    cityToBePosted = document.getElementById("autocomplete").value;
//    var mylat = autocomplete.getPlace().geometry.location.lat();
//    var mylng = autocomplete.getPlace().geometry.location.lng();
//    document.getElementById("cityLat").innerHTML = place.getPlace().geometry.location.lat();
//    document.getElementById("cityLng").value = place.getPlace().geometry.location.lng();

//}

// Bias the autocomplete object to the user's geographical location,
// as supplied by the browser's 'navigator.geolocation' object.
/*
function geolocate() {
  if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(function(position) {
      var geolocation = {
        lat: position.coords.latitude,
        lng: position.coords.longitude
      };
      var circle = new google.maps.Circle({
        center: geolocation,
        radius: position.coords.accuracy
      });
      autocomplete.setBounds(circle.getBounds());
    });
  }
} */
