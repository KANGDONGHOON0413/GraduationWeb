function setThumbnail(event) {
	var reader = new FileReader();

	reader.onload = function (event) {
		var img = document.createElement("img");
		img.setAttribute("src", event.target.result);
		img.setAttribute("style", "height:200px;");
		document.querySelector("div#image_container").appendChild(img);
	};

	reader.readAsDataURL(event.target.files[0]);
}