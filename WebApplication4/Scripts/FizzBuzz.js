﻿
var maxnumber = 101;
var badnum = false;

function llistFB() {

    this.addnode = function () {
        return { number: null, next: null };
    }

    this.start = null;
    this.end = null;

    this.add = function (numberi) {
        if (this.start === null) {
            this.start = this.addnode();
            this.end = this.start;
        }
        else {
            this.end.next = this.addnode();
            this.end = this.end.next;
        }
        this.end.number = numberi;
    }
}

function doMultiple() {
    var findit = nlistFB.start;
    masterstring = "";
    numcheck = 1;
    while (numcheck < maxnumber) {
        fizz = findit.number / numcheck;
        fizzfloor = Math.floor(fizz);
        fizz -= fizzfloor;
        if (fizz == 0) {
            stringFB = "Fizz";
        }
        else {
            stringFB = numcheck;
        }
        findit = findit.next;
        buzz = findit.number / numcheck;
        buzzfloor = Math.floor(buzz);
        buzz -= buzzfloor;
        if (buzz == 0) {
            if (stringFB == "Fizz") {
                stringFB += "Buzz";
            }
            else {
                stringFB = "Buzz";
            }
        }
        else {
            if (stringFB != "Fizz") {
                stringFB = numcheck;
            }
        }
        masterstring += stringFB + " "
        numcheck++;
        stringFB = "";
        findit = nlistFB.start;
    }
    document.getElementById("printbFB").innerHTML = masterstring;
}

function listHandlerFB() {
    var numberinFB = document.getElementById("numberinFB").value;
    document.getElementById("printbFB").innerText = "";
    if (numberinFB == "") {
        document.getElementById("printbFB").innerText = "No number entered";
        input = false;
        return;
    }
    if (numberinFB > 100) {
        badnum = true;
    }
    if (numberinFB < 1) {
        badnum = true;
    }
    numinfloor = Math.floor(numberinFB);
    fraccheck = numberinFB - numinfloor;
    if (fraccheck < 1 & fraccheck > 0) {
        badnum = true;
    }
    if (badnum) {
        document.getElementById("printbFB").innerText = "Please enter numbers 1-100 and no fractions";
    }
    else {
        nlistFB.add(numberinFB);
    }
}

function resetFB() {
    counterFB = 1;
    badnum = false;
    nlistFB = new llistFB();
    document.getElementById("submitFB").disabled = false;
    document.getElementById("goFB").disabled = true;
}

function setTextFB() {
    document.getElementById("textbFB").innerHTML = "Enter number " + counterFB;
    document.getElementById("numberinFB").value = "";
    document.getElementById("numberinFB").focus();
    counterFB++;
}

function checkInputFB() {
    if (badnum || !input) {
        document.getElementById("numberinFB").value = "";
        document.getElementById("numberinFB").focus();
        badnum = false;
        input = true;
    }
    else {
        if (counterFB >= 3) {
            document.getElementById("submitFB").disabled = true;
            document.getElementById("goFB").disabled = false;
            document.getElementById("numberinFB").value = "";
            document.getElementById("textbFB").innerHTML = "Numbers entered please click Go";
        }
        else
        {
            setTextFB();
        }
    }
}