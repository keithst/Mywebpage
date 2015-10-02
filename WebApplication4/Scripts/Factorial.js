
function doFactorial() {
    var numinF = document.getElementById("numberinF").value;
    if (numinF == "") {
        numinF = 1;
        window.alert("No number entered defaulting to 1")
    }
    var numsave = numinF
    if (numinF > 0) {
        while (numinF != 1) {
            resultF *= numinF;
            numinF--;
        }
        window.alert("Factoral of " + numsave + " is " + resultF);
    }
    else {
        window.alert("Error: Number entered is negative or 0.  Please enter a positive number.");
    }
}

function resetF() {
    resultF = 1;
    document.getElementById("numberinF").value = "";
    document.getElementById("numberinF").focus();
}