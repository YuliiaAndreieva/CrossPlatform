function generateSupplierInputs() {
    const supplierCount = document.getElementById("supplierCount").value;
    const suppliersContainer = document.getElementById("suppliersContainer");
    suppliersContainer.innerHTML = ""; 

    for (let i = 1; i <= supplierCount; i++) {
        const div = document.createElement("div");
        div.innerHTML = `
            <h4>Постачальник ${i}</h4>
            <label for="packs${i}">Кількість шкарпеток у пачці (a${i}):</label>
            <input type="number" id="packs${i}" name="Suppliers[${i - 1}].Packs" min="1" max="10000" required /><br /><br />
            <label for="price${i}">Ціна пачки (b${i}):</label>
            <input type="number" id="price${i}" name="Suppliers[${i - 1}].Price" min="1" max="10000" required /><br /><br />
        `;
        suppliersContainer.appendChild(div);
    }
}

function useExample() {
    document.getElementById("totalSocks").value = 9; 
    document.getElementById("supplierCount").value = 2; 
    generateSupplierInputs();
    document.getElementById("packs1").value = 1;
    document.getElementById("price1").value = 1;
    document.getElementById("packs2").value = 10;
    document.getElementById("price2").value = 8;
}
