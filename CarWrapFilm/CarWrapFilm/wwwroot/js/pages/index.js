"use strict";

import { getById } from '../common/functions.js';

const selected = "text-primary";

function removeSelectedRow(table) {
    for (const row of table.rows) {
        if (row.className === selected) {
            row.className = "";
            return;
        }
    }
}
function setFormDataAndScroll(serviceInput, serviceIdInput, row) {
    serviceInput.value = row.cells[0].textContent;
    serviceIdInput.value = parseInt(row.id);

    let form = getById("service-order-form");
    let rect = form.getBoundingClientRect();
    window.scrollBy(rect.x, rect.y);
}

document.addEventListener("DOMContentLoaded", e => {
    e.preventDefault();

    const serviceInput = getById("form-service-input");
    const serviceIdInput = getById("form-service-id-input");
    const tableKits = getById("table-kits").getElementsByTagName("tbody")[0];
    const tableWorks = getById("table-works").getElementsByTagName("tbody")[0];
    for (const row of tableKits.rows) {
        row.onclick = function (e) {
            e.preventDefault();
            $(this).addClass(selected).siblings().removeClass(selected);
            removeSelectedRow(tableWorks);
            setFormDataAndScroll(serviceInput, serviceIdInput, this);
        };
    }
    for (const row of tableWorks.rows) {
        row.onclick = function (e) {
            e.preventDefault();
            $(this).addClass(selected).siblings().removeClass(selected);
            removeSelectedRow(tableKits);
            setFormDataAndScroll(serviceInput, serviceIdInput, this);
        };
    }
});
