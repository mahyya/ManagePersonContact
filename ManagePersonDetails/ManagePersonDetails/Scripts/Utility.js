
function validateControl(input, validStr) {
    var temp;
    var tempStr = '';
    var tempFlag = true;
    var strVal = input.value;
    for (var i = 0; i < strVal.length; i++) {
        temp = strVal.substring(i, i + 1);
        // alert(temp);
        if (validStr.indexOf(temp) == -1) {
            // alert(tempStr);
            input.value = tempStr;
            input.focus();
            return false;
        }
        tempStr = tempStr + temp;

        //Added to remove initial spaces
        if (tempStr.substring(0, 1) == ' ') {
            tempStr = RemoveInitialWhiteSpace(strVal);
            input.value = tempStr;
            input.focus();
            return false;
        }

    }
    return true;
}

function autoName(input) {

    //var validStr='-_\',ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ';
    var validStr = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ';
    validateControl(input, validStr);
}

function autoNumeric(input) {
    var validStr = '0123456789';
    validateControl(input, validStr);
}