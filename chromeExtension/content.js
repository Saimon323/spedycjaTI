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

var prepareName = function(fullName)
{
	var values = fullName.split(" ");
	var names= [];
	for(var i=0; i<values.length; i++)
		if (values[i] != "")
			names.push(values[i]);
	return names;
}

var getName = function(fullName)
{
	names = prepareName(fullName);
	return names.length > 0 ? names[0] : " ";
}

var getLastName = function(fullName)
{
	names = prepareName(fullName);
	return names.length > 1 ? names[names.length - 1] : " ";
}

$(document).ready(function(){
	$(".contentRight").append("<button class='injection-button'>Wyślij dane z rozszerzenia</button>");

	var values = $(".contentRight tbody td p");

	var price = parseInt(getFormValue("Proponowana cena", values)) || 0;
	var weight = parseInt(getFormValue("Ciężar", values)) || 0;
	var fullName = getFormValue("Imię/nazwisko", values);

	var data= {
		LoadName: $(".contentRight tbody h3").text(),
		Type: getFormValue("Rodzaj", values),
		Weight: weight,
		Price: price,
		VehicleType: getFormValue("Naczepa", values),
		From: getFormChildValue("Transport", values, "b"),
		End: getFormChildValue("Transport", values, "font"),
		ClientName: getName(fullName),
		ClientLastName: getLastName(fullName),
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

