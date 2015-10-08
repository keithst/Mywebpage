
function doFactorial() {
    var numinF = document.getElementById("numberinF").value;
    if (numinF == "") {
        document.getElementById("printitF").innerText = "No number entered";
        return;
    }
    var numsave = numinF
    if (numinF > 0) {
        while (numinF != 1) {
            resultF *= numinF;
            numinF--;
        }
        document.getElementById("printitF").innerText = "Factoral of " + numsave + " is " + resultF;
    }
    else {
        document.getElementById("printitF").innerText = "Error: Number entered is negative or 0.  Please enter a positive number.";
    }
}

function resetF() {
    resultF = 1;
    document.getElementById("numberinF").value = "";
    document.getElementById("numberinF").focus();
}