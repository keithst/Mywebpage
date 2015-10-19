
function EditComment(inid) {
    if (document.getElementById("B " + inid).hidden == true)
    {
        document.getElementById("B " + inid).hidden = false;
    }
    else
    {
        document.getElementById("B " + inid).hidden = true;
    }

    if (document.getElementById("D " + inid).disabled == true) {
        document.getElementById("D " + inid).disabled = false;
    }
    else {
        document.getElementById("D " + inid).disabled = true;
    }

    if (document.getElementById("F " + inid).hidden == true)
    {
        document.getElementById("F " + inid).hidden = false;
    }
    else
    {
        document.getElementById("F " + inid).hidden = true;
    }

    if (document.getElementById("U " + inid).hidden == true)
    {
        if (document.getElementById("U " + inid).innerText === "Update Reason: ")
        {
            document.getElementById("U " + inid).hidden = true;
        }
        else
        {
            document.getElementById("U " + inid).hidden = false;
        }
    }
    else
    {
        document.getElementById("U " + inid).hidden = true;
    }
}

function Delete(inid) {
    if (document.getElementById("F" + inid).hidden == true) {
        document.getElementById("F" + inid).hidden = false;
    }
    else {
        document.getElementById("F" + inid).hidden = true;
    }
    document.getElementById("B" + inid).hidden = true;
}

function StopDelete(inid) {
    document.getElementById("FD " + inid).hidden = true;
    document.getElementById("BD " + inid).hidden = false;
}