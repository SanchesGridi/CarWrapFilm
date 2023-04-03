"use strict";

import { getById } from '/js/common/helpers.js';

class CartLine {
    constructor(serviceId, quantity) {
        this.serviceId = serviceId;
        this.quantity = quantity;
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

document.addEventListener("DOMContentLoaded", e => {
    e.preventDefault();

    const cartCalculator = {
        cartLines: [],
        addToCart(serviceId) {
            if (this.cartLines.length) {
                let cartLine = this.cartLines.find(x => x.serviceId === serviceId);
                if (cartLine) {
                    cartLine.add();
                } else {
                    this.cartLines.push(new CartLine(serviceId, 1));
                }
            } else {
                this.cartLines.push(new CartLine(serviceId, 1));
            }
        },
        removeFromCart(serviceId) {
            if (this.cartLines.length) {
                let cartLine = this.cartLines.find(x => x.serviceId === serviceId);
                if (cartLine) {
                    cartLine.remove();
                }
            }
        }
    };

    // handlers
    const table = getById("table-works-for-calculator").getElementsByTagName("tbody")[0];
    for (const row of table.rows) {
        let addButton = row.cells[2].children[0];
        let removeButton = row.cells[2].children[1];
        let serviceId = parseInt(row.id); // {i}_service_row_calculator
        addButton.addEventListener("click", e => {
            e.preventDefault();
            cartCalculator.addToCart(serviceId);
        });
        removeButton.addEventListener("click", e => {
            e.preventDefault();
            cartCalculator.removeFromCart(serviceId);
        });
    }

    getById("test-btn").addEventListener("click", e => { // test
        e.preventDefault();
        console.log(cartCalculator.cartLines);
    })
})