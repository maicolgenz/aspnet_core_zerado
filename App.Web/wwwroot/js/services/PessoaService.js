async function PessoaListaPessoas(nome, pesoMaiorQue, pesoMenorQue) {
    return new Promise((resolve, reject) => {
        Get('Pessoa/ListaPessoas?nome=' + nome + '&pesoMaiorQue=' +
            pesoMaiorQue + '&pesoMenorQue=' + pesoMenorQue).then(function (response) {
                console.log(response)
                if (response.status === 'success') {
                    resolve(response.data);
                } else {
                    reject(response.message);
                }
            }, function (err) {
                console.error(err);
                reject('Erro desconhecido');
            });
    });
}

async function PessoaBuscaPorId(id) {
    return new Promise((resolve, reject) => {
        Get('Pessoa/BuscaPorId?id=' + id).then(function (response) {
            if (response.status === 'success') {
                resolve(response.data);
            } else {
                reject(response.message);
            }
        }, function (err) {
            console.error(err);
            reject('Erro desconhecido');
        });
    });
}

async function PessoaSalvar(obj) {
    return new Promise((resolve, reject) => {
        Post('Pessoa/Salvar', obj).then(function (response) {
            if (response.status === 'success') {
                resolve(response.data);
            } else {
                reject(response.message);
            }
        }, function (err) {
            console.error(err);
            reject('Erro desconhecido');
        });
    });
}

async function PessoaRemover(id) {
    return new Promise((resolve, reject) => {
        Delete('Pessoa/Remover?id=' + id).then(function (response) {
            if (response.status === 'success') {
                resolve(response.data);
            } else {
                reject(response.message);
            }
        }, function (err) {
            console.error(err);
            reject('Erro desconhecido');
        });
    });
}
