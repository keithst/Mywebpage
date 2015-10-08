
function llistP() {

    this.addnode = function () {
        return { letter: null, next: null, back: null };
    }

    this.start = null;
    this.end = null;
    this.prev = null;

    this.add = function (letteri) {
        if (this.start === null) {
            this.start = this.addnode();
            this.end = this.start;
            this.prev = this.start;
        }
        else {
            this.end.next = this.addnode();
            this.end = this.end.next;
            this.end.back = this.prev;
            this.prev = this.end;
        }
        this.end.letter = letteri;
    }
}

function listHandlerP() {
    var stringin = document.getElementById("stringinP").value;
    document.getElementById("printbP").innerText = "";
    if (stringin == "")
    {
        document.getElementById("printbP").innerText = "No string entered";
        return;
    }
    var counter = 0;
    strlng = stringin.length;
    while (counter < strlng) {
        letterin = stringin.charAt(counter);
        nlistP.add(letterin);
        counter++;
    }
}

function Pali() {
    var findit = nlistP.start;
    var finditend = nlistP.end;
    var counter = 0;
    var stringit = "";
    while (counter < strlng) {
        if (findit.letter == finditend.letter) {
            palid = true;
        }
        else {
            palid = false;
        }
        stringit += findit.letter;
        findit = findit.next;
        finditend = finditend.back;
        counter++;
    }
    if (palid) {
        document.getElementById("printbP").innerText = stringit + " is a palindrome";
    }
    else {
        document.getElementById("printbP").innerText = stringit + " is not a palidrome";
    }
}

function resetP() {
    nlistP = new llistP();
}

function setTextP() {
    document.getElementById("textbP").innerHTML = "Enter a string";
    document.getElementById("stringinP").value = "";
    document.getElementById("stringinP").focus();
}