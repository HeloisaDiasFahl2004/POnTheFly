# POnTheFly
Funções criadas para o funcionamento do OnTheFly:
ValorConverter(float) retorno string - converte um valor float até 9.999,00 e retorna um string com obrigatóriamente 8 caracteres
(exemplo: 30 reais converte para 0.030,00 ou 100 reais converte para 0.100,00)
DateConverter(string data) retorno DateTime - converte um valor de data de string do tipo "02021992" e retorna DateTime 02/02/1992 00:00
(usado para converter a data de string para DateTime, na hora de instanciar um objeto)
DateHourConverter(string data) retorno DateTime - converte um valor de data com hora de string do tipo "020219921220" e retorna DateTime 02/02/1992 12:20
(usado para converter a data e hora de string para DateTime, na hora de instanciar um objeto)
GeradorIdPassagens(int capacidadeacentos) retorno List<string> - Gera os id's da quantidade de passagens recebida por parâmetro e 
Retorna uma lista<string> onde cada posição dessa lista é uma id de uma passagem no tipo string "PA0000"
Função: ValidarEntrada(String entrada);
- recebe uma string como parâmetros (listados logo a baixo)
- realiza um tratamento do um valor de entrada escolhido
- retorna o valor de entrada como string que pode ser convertido posteriormente
- Ou retorna nullo se o usuário cancelar a entrada dos dados
- Quando retornar NULL significa somente que é pra cancelar, voltar para o menu
parâmetros e retornos:
(menu) - retorna um STRING alfanumerio (qualquer numero digitado - Tratamento é feito no switch case do menu)
(cpf) - valida, procura se já existe. Se NÃO existir retorna 11 alfanumericos (para cadastro)
(cnpj) - valida, procura se já existe e se NÃO EXISTIR retorna 14 alfanumericos
(cnpjlogin) - valida, procura se já existe e se EXISTIR retorna 14 alfanumericos
(nome) - valida e retorna um nome/razaosocial obrigatoriamente com 50 caracteres (oq n for letra é espaço)
(sexo) - valida e retorna STRING maiúscula M / F / N
    
(datanascimento) - valida o nascimento e retorna um STRING de data com 8 caracteres
(dataabertura) - valida a data (Se for menos de 6 meses retorna NULL NA HORA!) se for válido retorna um STRING de data
(datavoo) - Valida e retorna um STRING de data com 12 caracteres, considera a hora
(idaeronave) - Informe o código Nacional de identificação da Aeronave: ... le o id da aeronave e verifica se é valido, depois se existe no arquivo. Se NÃO existir retorna o idaeronave. (Cadastro aeronave)
(capacidade) - valida quantidade de acentos e retorna STRING alfanumérico de 3 digitos
(situacao) - lê 1 ou 2 obrigatoriamente e retorna STRING maiúscula A ou I
(destino) - le o destino e verifica se existe no arquivo. Retorna o destino como string
(aeronave) - le o id da aeronave e verifica se existe no arquivo. Se existir retorna o idaeronave. (Cadastro voo)
(valorpassagem) - valida e retorna o valor da passagem como string("N2") - Não controla quantidade de casas. Para gravar usar o ValorConverter(float valor).
(idvenda) - verifica na lista de vendas se existe e retorna o valor
(cpflogin) - verifica se consta na lista de cadastro, verificar se esse objeto da lista é maior de 18, verificar se tem na lista restritos, retornar cpf (Para TelaOpcoesPassageiro).
(cpfexiste) - Se existir cpf na lista de passageiros, retorna o cpf, senão existir retorna null. (Para TelaLoginPassageiro).
(idvoo) - Verifica se existe na lista de voos um voo com esse id. Se existir retorna o idvoo (Para Tela de compras).
faltou criar a função: GeradorId(String string) retorno string
parâmetros:
(idvoo) - Gera e retorna um idVoo único que não existe na lista de voo
(idvenda) - Gera e retorna um idVenda único que não existe na lista de vendas, iniciará em 1 e vai até 99.999
Retorna obrigatóriamente 6 caracteres considerando o ponto.
(iditemvenda) - Gera e retorna um idVenda único que não existe na lista de vendas, iniciará em 1 e vai até 99.999
Retorna obrigatóriamente 6 caracteres considerando o ponto.
