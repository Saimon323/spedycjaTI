var getFormValue = function(name, values){
	var returnValue;
	values.each(function(i, value){
		if(!_.str.startsWith($(value).html(), name))
			return;
		returnValue = $(values[i+1]).text();
	})
	return returnValue;
}

var getFormChildValue = function(name, values, child){
	var returnValue;
	values.each(function(i, value){
		if(!_.str.startsWith($(value).html(), name))
			return;
		returnValue = $(values[i+1]).children(child).text();
	})
	return returnValue;
}

$(document).ready(function(){
	$(".contentRight").append("<button class='injection-button'>Wyślij dane z rozszerzenia</button>");

	var values = $(".contentRight tbody td p");

	var data= {
		LoadName: $(".contentRight tbody h3").text(),
		Type: getFormValue("Rodzaj", values),
		Weight: getFormValue("Ciężar", values),
		Volume: getFormValue("Objętość", values),
		Price: getFormValue("Proponowana cena", values),
		VehicleType: getFormValue("Naczepa", values),
		From: getFormChildValue("Transport", values, "b"),
		End: getFormChildValue("Transport", values, "font"),
		ClientName: getFormValue("Imię/nazwisko", values),
		ClientCompany: getFormValue("Firma", values),
		ClientPhone: getFormValue("Telefon", values),
		ClientAdress: getFormValue("Adres", values)	
	}

	$(".injection-button").click(function(){
		chrome.runtime.sendMessage({data: data}, function(response) {
		  console.log(response.ACK);
		});
	});
});

