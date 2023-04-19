"use strict";

import { getById, createElement } from '../common/functions.js';
import { Cart } from '../common/cart.js';

function createHiddenInput(name, value) {
    let input = createElement("input");
    input.type = "hidden";
    input.name = name;
    input.value = value;
    return input;
}

function createStrongElement(className, textContent) {
    let strong = createElement("strong");
    strong.className = className;
    strong.textContent = textContent;
    return strong;
}

function updateForm(cart) {
    let serviceContainer = getById("works-container");
    let formContainer = getById("form-container");

    if (!cart.cartLines.length) {
        serviceContainer.textContent = "Отсутствуют";
        serviceContainer.className = "text-center";
        formContainer.style.display = "none";
    } else {
        serviceContainer.textContent = "";
        serviceContainer.className = ""
        formContainer.style.display = "block";

        let index = 0;
        let order = 1;
        let totalPrice = 0;
        for (const cartLine of cart.cartLines) {
            let entry = createElement("div");
            entry.className = "form-group";

            let idInput = createHiddenInput(`works[${index}].Id`, cartLine.serviceId);
            let countInput = createHiddenInput(`works[${index}].Count`, cartLine.quantity);
            let nameInput = createHiddenInput(`works[${index}].Name`, cartLine.name);
            let priceInput = createHiddenInput(`works[${index++}].Price`, cartLine.price);
            let description = createStrongElement(
                "form-text text-black",
                `${order++}) ${cartLine.name} (стоимость - ${cartLine.price}) [${cartLine.quantity} поз.]`
            );

            entry.appendChild(idInput);
            entry.appendChild(countInput);
            entry.appendChild(nameInput);
            entry.appendChild(priceInput);
            entry.appendChild(description);

            serviceContainer.appendChild(entry);

            totalPrice += parseInt(cartLine.price.split(" ")[1]) * cartLine.quantity;
        }
        serviceContainer.appendChild(createStrongElement(
            "form-text text-black",
            `Итоговая стоимость: от ${totalPrice} BYN`
        ));
    }
}

document.addEventListener("DOMContentLoaded", e => {
    e.preventDefault();

    const cart = new Cart();
    updateForm(cart);
    const table = getById("table-works-for-calculator").getElementsByTagName("tbody")[0];
    for (const row of table.rows) {
        let serviceId = parseInt(row.id);
        let serviceName = row.cells[0].children[0].textContent;
        let servicePrice = row.cells[1].textContent;
        let addButton = row.cells[2].children[0];
        let removeButton = row.cells[2].children[1];
        addButton.addEventListener("click", e => {
            e.preventDefault();
            cart.add(serviceId, serviceName, servicePrice);
            updateForm(cart);
        });
        removeButton.addEventListener("click", e => {
            e.preventDefault();
            cart.remove(serviceId);
            updateForm(cart);
        });
    }
})