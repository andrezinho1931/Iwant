// Funçoes para abrir e fechar a modal
function openModal(foto, nome, descricao, contato, preco) {
    document.getElementById("modalImage").src = "/imagens/" + foto;
    document.getElementById("modalName").textContent = nome;
    document.getElementById("modalDescription").textContent = descricao;
    document.getElementById("modalContact").textContent = "Entre em Contato: " + contato;
    document.getElementById("modalPrice").textContent = "Preço: " + preco;

    document.getElementById("productModal").style.display = "block";
}

function closeModal() {
    document.getElementById("productModal").style.display = "none";
}


