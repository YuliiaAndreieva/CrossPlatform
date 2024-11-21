function generateLabyrinthInputs() {
    const rows = document.getElementById("rows").value;
    const cols = document.getElementById("cols").value;
    const labyrinthContainer = document.getElementById("labyrinthContainer");
    labyrinthContainer.innerHTML = "";

    for (let r = 0; r < rows; r++) {
        const rowDiv = document.createElement("div");
        for (let c = 0; c < cols; c++) {
            const cellInput = document.createElement("input");
            cellInput.type = "text";
            cellInput.name = `Labyrinth[${r}][${c}]`;
            cellInput.maxLength = 1;
            cellInput.style.width = "20px";
            rowDiv.appendChild(cellInput);
        }
        labyrinthContainer.appendChild(rowDiv);
    }
}

function useExample() {
    document.getElementById("rows").value = 6;
    document.getElementById("cols").value = 6;
    document.getElementById("keyPricesR").value = 1;
    document.getElementById("keyPricesG").value = 5;
    document.getElementById("keyPricesB").value = 3;
    document.getElementById("keyPricesY").value = 1;

    generateLabyrinthInputs();

    const exampleLabyrinth = [
        "XXXXXX",
        "XS.X.X",
        "X..R.X",
        "X.XXBX",
        "X.G.EX",
        "XXXXXX"
    ];

    const inputs = document.querySelectorAll("#labyrinthContainer input");
    let index = 0;
    exampleLabyrinth.forEach(row => {
        row.split('').forEach(cell => {
            inputs[index++].value = cell;
        });
    });
}
