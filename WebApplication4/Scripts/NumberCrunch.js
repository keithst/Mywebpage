
function llist() {

    this.addnode = function () {
        return { count: null, number: null, next: null };
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
        this.end.count++;
    }

    this.find = function (numberi) {
        var findit = this.start;
        var foundit = 0;
        while (findit !== null) {
            if (findit.number === numberi) {
                findit.count++;
                foundit = 1;
            }
            findit = findit.next;
        }
        if (foundit == 0) {
            this.add(numberi);
        }
    }

    this.numcrunch = function () {
        var findit = this.start;
        var loopcnt = 0;
        greatest = findit.number
        least = findit.number
        var work = 0;
        while (findit !== null) {
            if (findit.number > greatest) {
                greatest = findit.number;
            }
            if (findit.number < least) {
                least = findit.number;
            }
            work = findit.number * findit.count;
            ncount += findit.count;
            sum += work;
            loopcnt = findit.count;
            while (loopcnt > 0)
            {
                product *= findit.number;
                loopcnt--;
            }
            findit = findit.next;
        }
    }
}

function listHandler() {
    var numin = document.getElementById("numberin").value;
    if (numin == "")
    {
        numin = 1;
        window.alert("No number entered defaulting to 1")
    }
    nlist.find(numin);
}

function reset() {
    counter = 1;
    sum = 0;
    product = 1;
    least = 0;
    greatest = 0;
    mean = 0;
    ncount = 0;
    nlist = new llist();
}

function getFinal() {
    nlist.numcrunch();
    mean = sum / ncount;
    window.alert("The lowest number is " + least + "\nThe greastest number is " + greatest +
                 "\nThe mean is " + mean + "\nThe sum of all numbers is " + sum +
                 "\nThe product of all numbers is " + product);
}

function setText() {
    document.getElementById("textb").innerHTML = "Enter number " + counter;
    document.getElementById("numberin").value = "";
    document.getElementById("numberin").focus();
    counter++;
}