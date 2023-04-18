"use strict";

import { getById, createElement } from '/js/common/functions.js';

class CartLine {
    constructor(serviceId, quantity, name, price) {
        this.serviceId = serviceId;
        this.quantity = quantity;
        this.name = name;
        this.price = price;
    }
    add() {
        ++this.quantity;
    }
    remove() {
        if (this.quantity) {
            --this.quantity;
        }
    }
}

function createHiddenInput(name, value) {
    let input = createElement("input");
    input.type = "hidden";
    input.name = name;
    input.value = value;
    return input;
}

document.addEventListener("DOMContentLoaded", e => {
    e.preventDefault();

    const cartCalculator = {
        cartLines: [],
        addToCart(id, name, price) {
            if (this.cartLines.length) {
                let cartLine = this.cartLines.find(x => x.serviceId === id);
                if (cartLine) {
                    cartLine.add();
                } else {
                    this.cartLines.push(new CartLine(id, 1, name, price));
                }
            } else {
                this.cartLines.push(new CartLine(id, 1, name, price));
            }
        },
        removeFromCart(serviceId) {
            if (this.cartLines.length) {
                let cartLine = this.cartLines.find(x => x.serviceId === serviceId);
                if (cartLine) {
                    cartLine.remove();
                    if (!cartLine.quantity) {
                        let index = this.cartLines.indexOf(cartLine);
                        if (index !== -1) {
                            this.cartLines.splice(index, 1);
                        }
                    }
                }
            }
        },
        updateForm() {
            let serviceContainer = getById("works-container");
            let formContainer = getById("form-container");

            if (!this.cartLines.length) {
                serviceContainer.textContent = "Отсутствуют";
                serviceContainer.className = "text-center";
                formContainer.style.display = "none";
            } else {
                serviceContainer.textContent = "";
                serviceContainer.className = ""
                formContainer.style.display = "block";

                let index = 0;
                let order = 1;
                for (const cartLine of this.cartLines) {
                    let entry = createElement("div");
                    entry.className = "form-group";

                    let idInput = createHiddenInput(`works[${index}].Id`, cartLine.serviceId);
                    let countInput = createHiddenInput(`works[${index}].Count`, cartLine.quantity);
                    let nameInput = createHiddenInput(`works[${index}].Name`, cartLine.name);
                    let priceInput = createHiddenInput(`works[${index++}].Price`, cartLine.price);

                    let description = createElement("strong");
                    description.className = "form-text text-black";
                    description.textContent = `${order++}) ${cartLine.name} (стоимость - ${cartLine.price}) [${cartLine.quantity} поз.]`;

                    entry.appendChild(idInput);
                    entry.appendChild(countInput);
                    entry.appendChild(nameInput);
                    entry.appendChild(priceInput);
                    entry.appendChild(description);

                    serviceContainer.appendChild(entry);
                }
            }
        }
    };
    cartCalculator.updateForm();

    // handlers
    const table = getById("table-works-for-calculator").getElementsByTagName("tbody")[0];
    for (const row of table.rows) {
        let serviceId = parseInt(row.id);
        let serviceName = row.cells[0].children[0].textContent;
        let servicePrice = row.cells[1].textContent;

        let addButton = row.cells[2].children[0];
        let removeButton = row.cells[2].children[1];
        addButton.addEventListener("click", e => {
            e.preventDefault();
            cartCalculator.addToCart(serviceId, serviceName, servicePrice);
            cartCalculator.updateForm();
        });
        removeButton.addEventListener("click", e => {
            e.preventDefault();
            cartCalculator.removeFromCart(serviceId);
            cartCalculator.updateForm();
        });
    }
})