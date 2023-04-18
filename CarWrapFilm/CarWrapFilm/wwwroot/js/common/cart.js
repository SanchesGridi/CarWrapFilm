"use strict";

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

export class Cart {
    constructor() {
        this.cartLines = [];
    }
    add(id, name, price) {
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
    }
    remove(serviceId) {
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
    }
}
