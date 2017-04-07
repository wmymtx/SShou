function checkName(val){
	if(removeAllSpace(val) == "")
	{
		return false;
	}
	else{
		return true;
	}
}
function checkPhone(val){
	var re = /^1\d{10}$/
    if (re.test(val)) {
       return true;
    } else {
       return false;
    }
}
function checkAddress(val){
	if(removeAllSpace(val) == ""){
		return false;
	}
	else{
		return true;
	}
}
function removeAllSpace(str) {
	return str.replace(/\s+/g, "");
}