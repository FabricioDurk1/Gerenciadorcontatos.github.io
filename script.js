const form = document.getElementById('form');
const contactsList = document.getElementById('contacts-list');

let contacts = [];


function addContact(name, email, phone) {
    contacts.push({ name, email, phone });
    renderContacts();
}


function renderContacts() {
    contactsList.innerHTML = '';
    contacts.forEach((contact, index) => {
        const contactItem = document.createElement('div');
        contactItem.classList.add('contact-item');
        contactItem.innerHTML = `
            <strong>${contact.name}</strong> - ${contact.email} - ${contact.phone}
            <button onclick="editContact(${index})">Editar</button>
            <button onclick="deleteContact(${index})">Excluir</button>
        `;
        contactsList.appendChild(contactItem);
    });
}


function editContact(index) {
    const { name, email, phone } = contacts[index];
    const newName = prompt('Novo nome:', name);
    const newEmail = prompt('Novo email:', email);
    const newPhone = prompt('Novo telefone:', phone);
    contacts[index] = { name: newName, email: newEmail, phone: newPhone };
    renderContacts();
}

function deleteContact(index) {
    contacts.splice(index, 1);
    renderContacts();
}

form.addEventListener('submit', function(event) {
    event.preventDefault();
    const name = document.getElementById('name').value;
    const email = document.getElementById('email').value;
    const phone = document.getElementById('phone').value;
    addContact(name, email, phone);
    form.reset();
});


renderContacts();