
function EditComment(inid) {
    if (document.getElementById("B " + inid).hidden == true)
    {
        document.getElementById("B " + inid).hidden = false;
    }
    else
    {
        document.getElementById("B " + inid).hidden = true;
    }

    if (document.getElementById("T " + inid).hidden == true)
    {
        document.getElementById("T " + inid).hidden = false;
    }
    else
    {
        document.getElementById("T " + inid).hidden = true;
    }

    if (document.getElementById("U " + inid).hidden == true)
    {
        if (document.getElementById("U " + inid).innerText === "Update: ")
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

    if (document.getElementById("UE " + inid).hidden == true)
    {
        document.getElementById("UE " + inid).hidden = false;
    }
    else
    {
        document.getElementById("UE " + inid).hidden = true;
    }
}