using Proj_POG_OnTheFly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace POnTheFly
{
    internal class Program
    {
        static List<Passageiro> listPassageiro = new List<Passageiro>();
        static List<CompanhiaAerea> listCompanhia = new List<CompanhiaAerea>();
        static List<Aeronave> listAeronaves = new List<Aeronave>();
        static List<Voo> listVoo = new List<Voo>();
        static List<PassagemVoo> listPassagem = new List<PassagemVoo>();
        static List<Venda> listVenda = new List<Venda>();
        static List<ItemVenda> listItemVenda = new List<ItemVenda>();
        static List<string> listRestritos = new List<string>();
        static List<string> listBloqueados = new List<string>();
        static List<string> listDestino = new List<string>();
        
        #region Conversoes Datas
        static public DateTime DateConverter(string data)
        {
            char[] datasembarra = data.ToCharArray();
            char[] datacombarra = new char[] { datasembarra[0], datasembarra[1], '/', datasembarra[2], datasembarra[3], '/', datasembarra[4], datasembarra[5], datasembarra[6], datasembarra[7] };
            string datacombarras = null;
            for (int i = 0; i < 10; i++)
            {
                datacombarras = datacombarras + datacombarra[i];
            }
            return DateTime.Parse(datacombarras);
        }
        static public DateTime DateHourConverter(string datahora)
        {
            char[] datahorastring = datahora.ToCharArray();
            char[] datahoracombarra = new char[] { datahorastring[0], datahorastring[1], '/', datahorastring[2], datahorastring[3], '/', datahorastring[4], datahorastring[5], datahorastring[6], datahorastring[7], ' ', datahorastring[8], datahorastring[9], ':', datahorastring[10], datahorastring[11] };
            string datacombarras = null;
            foreach (var v in datahoracombarra)
            {
                datacombarras = datacombarras + v;
            }
            return DateTime.Parse(datacombarras);
        }
        #endregion

        #region Pausas
        static bool PausaMensagem()
        {
            bool repetirdo;
            do
            {
                Console.WriteLine("\nPressione S para informar novamente ou C para cancelar cadastro:");
                ConsoleKeyInfo op = Console.ReadKey(true);
                if (op.Key == ConsoleKey.S)
                {
                    Console.Clear();
                    return false;
                }
                else
                {
                    if (op.Key == ConsoleKey.C)
                    {
                        Console.Clear();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Escolha uma opção válida!");
                        repetirdo = true;
                    }
                }
            } while (repetirdo == true);
            return true;
        }
        static void Pausa() // OK 
        {
            Console.WriteLine("\nAperte 'ENTER' para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion

        #region GravarCarregar
        //Metodo para gravar o arquivo no diretorio em .dat
        static void GravarPassageiro(List<Passageiro> listPassageiro)
        {
            StreamWriter gravPassageiro = new StreamWriter(@"C:\DBOnTheFly\Passageiro.dat");
            foreach (var passageiro in listPassageiro)
            {
                gravPassageiro.WriteLine(passageiro.ObterDados());
            }
            gravPassageiro.Close();
        }
        static void GravarCompanhiaAerea(List<CompanhiaAerea> listCompanhia)
        {
            StreamWriter gravCompAerea = new StreamWriter(@"C:\DBOnTheFly\CompanhiaAerea.dat");
            foreach (var companhiaaerea in listCompanhia)
            {
                gravCompAerea.WriteLine(companhiaaerea.ObterDados());
            }
        }
        static void GravarAeronaves(List<Aeronave> listAeronaves)
        {
            StreamWriter gravAeronaves = new StreamWriter(@"C:\DBOnTheFly\Aeronaves.dat");
            foreach (var aeronaves in listAeronaves)
            {
                gravAeronaves.WriteLine(aeronaves.ObterDados());
            }
        }
        static void GravarVoo(List<Voo> listVoo)
        {
            StreamWriter gravVoo = new StreamWriter(@"C:\DBOnTheFly\Voo.dat");
            foreach (var voo in listVoo)
            {
                gravVoo.WriteLine(voo.ObterDados());
            }
        }
        static void GravarPassagem(List<PassagemVoo> listPassagem)
        {
            StreamWriter gravPassagem = new StreamWriter(@"C:\DBOnTheFly\Passagem.dat");
            foreach (var passagem in listPassagem)
            {
                gravPassagem.WriteLine(passagem.ObterDados());
            }
        }
        static void GravarVenda(List<Venda> listVenda)
        {
            StreamWriter gravVenda = new StreamWriter(@"C:\DBOnTheFly\Venda.dat");
            foreach (var venda in listVenda)
            {
                gravVenda.WriteLine(venda.ObterDados());
            }
        }
        static void GravarItemVenda(List<ItemVenda> listItemVenda)
        {
            StreamWriter gravItemVenda = new StreamWriter(@"C:\DBOnTheFly\ItemVenda.dat");
            foreach (var itemvenda in listItemVenda)
            {
                gravItemVenda.WriteLine(itemvenda.ObterDados());
            }
        }
        static void GravarRestritos(List<string> listRestritos)
        {
            StreamWriter gravRestritos = new StreamWriter(@"C:\DBOnTheFly\Restritos.dat");
            foreach (var restritos in listRestritos)
            {
                gravRestritos.WriteLine(restritos);
            }
        }
        static void GravarBloqueados(List<string> listBloqueados)
        {
            StreamWriter gravBloqueados = new StreamWriter(@"C:\DBOnTheFly\Bloqueados.dat");
            foreach (var bloqueados in listBloqueados)
            {
                gravBloqueados.WriteLine(bloqueados);
            }
        }

        static void CarregarArquivos()
        {
            //Prop.Passageiro
            string cpf = null;
            string nome = null;
            char Sexo;
            DateTime DataNascimento;
            DateTime DataUltimaCompra;
            //Prop.CompanhiaAerea
            string Cnpj = null;
            string RazaoSocial = null;
            DateTime DataAbertura;
            DateTime UltimoVoo;
            //Prop.Aeronaves
            string Inscricao = null;
            int Capacidade = 0;
            int Assentos = 0;
            DateTime UltimaVenda;
            //Prop.Voo
            string IDVoo = null;
            string Destino = null;
            string Aeronave = null;
            DateTime DataVoo;
            //Prop.PassagemVoo
            string IDPassagem = null;
            DateTime DataUltimaOperacao;
            //Prop.Venda
            string IDVenda = null;
            DateTime DataVenda;
            string CpfPassageiro = null;
            //Prop.ItemVenda
            string IDItemVenda = null;
            DateTime DataCadastro;
            string data = null;
            char Situacao;
            float Valor;
            string valor = null;
            char[] caracteres;
            string[] linhas;
            //Passageiro
            try
            {
                linhas = System.IO.File.ReadAllLines(@"C:\DBOnTheFly\Passageiro.dat");
                foreach (var linha in linhas)
                {
                    caracteres = linha.ToCharArray();
                    for (int i = 0; i <= 10; i++)
                    {
                        cpf = cpf + caracteres[i].ToString();
                    }
                    for (int i = 11; i <= 61; i++)
                    {
                        nome = nome + caracteres[i].ToString();
                    }
                    for (int i = 62; i <= 69; i++)
                    {
                        data = data + caracteres[i].ToString();
                    }
                    DataNascimento = DateConverter(data);
                    Sexo = caracteres[70];
                    for (int i = 71; i <= 82; i++)
                    {
                        data = data + caracteres[i].ToString();
                    }
                    DataUltimaCompra = DateHourConverter(data);
                    for (int i = 83; i <= 94; i++)
                    {
                        data = data + caracteres[i].ToString();
                    }
                    DataCadastro = DateHourConverter(data);
                    Situacao = caracteres[95];
                    Passageiro P = new Passageiro(cpf, nome, DataNascimento, Sexo, DataUltimaCompra, DataCadastro, Situacao);
                    listPassageiro.Add(P);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Mensagem de Erro: Não foi possível carregar dados do arquivo Passageiro.dat");
            }
            //Companhia Aerea
            try
            {
                linhas = System.IO.File.ReadAllLines(@"C:\DBOnTheFly\CompanhiaAerea.dat");
                foreach (var linha in linhas)
                {
                    caracteres = linha.ToCharArray();
                    for (int i = 0; i <= 13; i++)
                    {
                        Cnpj = Cnpj + caracteres[i].ToString();
                    }
                    for (int i = 14; i <= 63; i++)
                    {
                        RazaoSocial = RazaoSocial + caracteres[i].ToString();
                    }
                    for (int i = 64; i <= 71; i++)
                    {
                        data = data + caracteres[i].ToString();
                    }
                    DataAbertura = DateConverter(data);
                    for (int i = 72; i <= 83; i++)
                    {
                        data = data + caracteres[i].ToString();
                    }
                    UltimoVoo = DateHourConverter(data);
                    for (int i = 84; i <= 95; i++)
                    {
                        data = data + caracteres[i].ToString();
                    }
                    DataCadastro = DateHourConverter(data);
                    Situacao = caracteres[96];
                    CompanhiaAerea CA = new CompanhiaAerea(Cnpj, RazaoSocial, DataAbertura, UltimoVoo, DataCadastro, Situacao);
                    listCompanhia.Add(CA);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Mensagem de Erro: Não foi possível carregar dados do arquivo CompanhiaAerea.dat");
            }
            //Aeronaves
            try
            {
                linhas = System.IO.File.ReadAllLines(@"C:\DBOnTheFly\Aeronave.dat");
                foreach (var linha in linhas)
                {
                    caracteres = linha.ToCharArray();
                    for (int i = 0; i <= 5; i++)
                    {
                        Inscricao = Inscricao + caracteres[i].ToString();
                    }
                    for (int i = 6; i <= 8; i++)
                    {
                        Capacidade = Capacidade + caracteres[i];
                    }
                    for (int i = 9; i <= 11; i++)
                    {
                        Assentos = Assentos + caracteres[i];
                    }
                    for (int i = 12; i <= 23; i++)
                    {
                        data = data + caracteres[i].ToString();
                    }
                    UltimaVenda = DateHourConverter(data);
                    for (int i = 24; i <= 35; i++)
                    {
                        data = data + caracteres[i].ToString();
                    }
                    DataCadastro = DateHourConverter(data);
                    Situacao = caracteres[36];
                    Aeronave Aer = new Aeronave(Inscricao, Capacidade, Assentos, UltimaVenda, DataCadastro, Situacao);
                    listAeronaves.Add(Aer);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Mensagem de Erro:  Não foi possível carregar dados do arquivo Aeronave.dat ");
            }
            //Voo
            try
            {
                linhas = System.IO.File.ReadAllLines(@"C:\DBOnTheFly\Voo.dat");
                foreach (var linha in linhas)
                {
                    caracteres = linha.ToCharArray();
                    for (int i = 0; i <= 4; i++)
                    {
                        IDVoo = IDVoo + caracteres[i].ToString();
                    }
                    for (int i = 5; i <= 7; i++)
                    {
                        Destino = Destino + caracteres[i].ToString();
                    }
                    for (int i = 8; i <= 13; i++)
                    {
                        Aeronave = Aeronave + caracteres[i].ToString();
                    }
                    for (int i = 14; i <= 25; i++)
                    {
                        data = data + caracteres[i].ToString();
                    }
                    DataVoo = DateHourConverter(data);
                    for (int i = 26; i <= 37; i++)
                    {
                        data = data + caracteres[i].ToString();
                    }
                    DataCadastro = DateHourConverter(data);
                    Situacao = caracteres[38];
                    Voo V = new Voo(IDVoo, Destino, Aeronave, DataVoo, DataCadastro, Situacao);
                    listVoo.Add(V);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Mensagem de Erro: Não foi possível carregar dados do arquivo Voo.dat");
            }
            //PassagemVoo
            try
            {
                linhas = System.IO.File.ReadAllLines(@"C:\DBOnTheFly\PassagemVoo.dat");
                foreach (var linha in linhas)
                {
                    caracteres = linha.ToCharArray();
                    for (int i = 0; i < 5; i++)
                    {
                        IDPassagem = IDPassagem + caracteres[i].ToString();
                    }
                    for (int i = 6; i <= 10; i++)
                    {
                        IDVoo = IDVoo + caracteres[i].ToString();
                    }
                    for (int i = 11; i <= 22; i++)
                    {
                        data = data + caracteres[i].ToString();
                    }
                    DataUltimaOperacao = DateHourConverter(data);
                    for (int i = 22; i <= 28; i++)
                    {
                        valor = valor + caracteres[i].ToString();
                    }
                    Valor = float.Parse(valor);
                    Situacao = caracteres[29];
                    PassagemVoo PV = new PassagemVoo(IDPassagem, IDVoo, DataUltimaOperacao, Valor, Situacao);
                    listPassagem.Add(PV);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Mensagem de Erro: Não foi possível carregar dados do arquivo PassagemVoo.dat ");
            }
            //Venda
            try
            {
                linhas = System.IO.File.ReadAllLines(@"C:\DBOnTheFly\Venda.dat");
                foreach (var linha in linhas)
                {
                    caracteres = linha.ToCharArray();
                    for (int i = 0; i < 4; i++)
                    {
                        IDVenda = IDVenda + caracteres[i].ToString();
                    }
                    for (int i = 5; i <= 16; i++)
                    {
                        data = data + caracteres[i].ToString();
                    }
                    DataVenda = DateHourConverter(data);
                    for (int i = 17; i <= 27; i++)
                    {
                        CpfPassageiro = CpfPassageiro + caracteres[i].ToString();
                    }
                    for (int i = 27; i <= 34; i++)
                    {
                        valor = valor + caracteres[i].ToString();
                    }
                    Valor = float.Parse(valor);
                    Venda Vend = new Venda(IDVenda, DataVenda, CpfPassageiro, Valor);
                    listVenda.Add(Vend);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Mensagem de Erro: Não foi possível carregar dados do arquivo Venda.dat");
            }
            //ItemVenda
            try
            {
                linhas = System.IO.File.ReadAllLines(@"C:\DBOnTheFly\ItemVenda.dat");
                foreach (var linha in linhas)
                {
                    caracteres = linha.ToCharArray();
                    for (int i = 0; i < 4; i++)
                    {
                        IDItemVenda = IDItemVenda + caracteres[i].ToString();
                    }
                    for (int i = 5; i <= 10; i++)
                    {
                        IDPassagem = IDPassagem + caracteres[i].ToString();
                    }
                    for (int i = 11; i <= 17; i++)
                    {
                        valor = valor + caracteres[i].ToString();
                    }
                    Valor = float.Parse(valor);
                    ItemVenda IV = new ItemVenda(IDItemVenda, IDPassagem, Valor);
                    listItemVenda.Add(IV);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Mensagem de Erro: Não foi possível carregar dados do arquivo ItemVenda.dat");
            }
            //Restritos
            try
            {
                linhas = System.IO.File.ReadAllLines(@"C:\DBOnTheFly\Restritos.dat");
                foreach (var linha in linhas)
                {
                    listRestritos.Add(linha);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Mensagem de Erro: Não foi possível carregar dados do arquivo Restritos.dat");
            }
            //Bloqueados
            try
            {
                linhas = System.IO.File.ReadAllLines(@"C:\DBOnTheFly\Bloqueados.dat");
                foreach (var linha in linhas)
                {
                    listBloqueados.Add(linha);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Mensagem de Erro: Não foi possível carregar dados do arquivo Bloqueados.dat");
            }
            //Destino
            try
            {
                linhas = System.IO.File.ReadAllLines(@"C:\DBOnTheFly\Destino.dat");
                foreach (var linha in linhas)
                {
                    listDestino.Add(linha);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Mensagem de Erro: Não foi possível carregar dados do arquivo Destino.dat");
            }
        }


        #endregion GravarCarregar

        #region Validacoes
        static public string ValidarEntrada(string entrada)
        {
            string[] vetorletras = new string[] {"Ç","ç","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S",
            "T","U","V","W","X","Y","Z","Á","É","Í","Ó","Ú","À","È","Ì","Ò","Ù","Â","Ê","Î","Ô","Û","Ã","Õ"," "};
            string[] vetornumeros = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            bool encontrado;
            bool retornar = true;
            int qtdnumerosiguais = 0;


            switch (entrada)
            {
                case "menu":

                    #region menu

                    do
                    {

                        try
                        {
                            char[] vetortecla;
                            Console.CursorVisible = false;
                            ConsoleKeyInfo op = Console.ReadKey(true);
                            vetortecla = op.Key.ToString().ToCharArray();

                            if (vetortecla[0] == 'N')
                            {
                                if (vetornumeros.Contains(vetortecla[6].ToString()) == true)
                                {
                                    return vetortecla[6].ToString();
                                }
                                else
                                {
                                    encontrado = false;
                                }
                            }
                            else
                            {
                                if (vetortecla[0] == 'D')
                                {
                                    if (vetornumeros.Contains(vetortecla[1].ToString()) == true)
                                    {
                                        return vetortecla[1].ToString();
                                    }
                                    else
                                    {
                                        encontrado = false;
                                    }
                                }
                                else
                                {
                                    encontrado = false;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            encontrado = false;
                        }
                    } while (encontrado == false);

                    return null;


                #endregion


                case "cpf":

                    #region CPF;

                    do
                    {
                        //Seta encontrado e validado sempre que retorna o laço do processo:
                        encontrado = true; // seta true para não quebrar o for de primeira
                        retornar = false; // só retorna se o usuário quiser
                        qtdnumerosiguais = 0;
                        string cpf;

                        try
                        {
                            Console.Clear();
                            Console.Write("Informe o CPF: ");

                            cpf = Console.ReadLine();

                            char[] letras = cpf.ToCharArray();

                            //verifica se tem 11 caracteres:
                            if (letras.Length == 11)
                            {
                                //verifica os 11 caracteres se são obrigatóriamente números:
                                for (int i = 0; i < 11 && encontrado != false; i++)
                                {
                                    foreach (var v in vetornumeros)
                                    {
                                        if (letras[i].ToString().ToUpper().Equals(v))
                                        {
                                            encontrado = true;
                                            break; // sai do foreach e volta pro for
                                        }
                                        else encontrado = false;
                                    }
                                }

                                //Verifica se é um cpf válido calculando os 2 últimos digitos, segundo a receita federal:
                                if (encontrado == true)
                                {
                                    int soma = 0;
                                    int resto = 0;
                                    int digito1 = 0;
                                    int digito2 = 0;

                                    //Verifica se os números são iguais

                                    for (int i = 0; i < 9; i++)
                                    {
                                        if (letras[i] == letras[i + 1])
                                            qtdnumerosiguais = qtdnumerosiguais + 1;

                                    }

                                    //Se os 9 primeiros digitos forem todos iguais, invalida o cpf:
                                    if (qtdnumerosiguais != 9)
                                    {
                                        //calcula o primeiro digito verificador do cpf:
                                        for (int i = 1, j = 0; i < 10; i++, j++)
                                            soma = soma + (int.Parse(letras[j].ToString()) * i);

                                        resto = soma % 11;

                                        if (resto >= 10)
                                        {
                                            digito1 = 0;

                                        }
                                        else
                                        {
                                            digito1 = resto;
                                        }

                                        //Verifica se o primeiro digito digitado é igual ao que era pra ser:
                                        if (digito1 == int.Parse(letras[9].ToString()))
                                        {
                                            soma = 0; //seta o soma em 0 para o processo de soma do segundo digito do cpf:

                                            //calcula o segundo digito verificador do cpf:
                                            for (int i = 0, j = 0; i < 10; i++, j++)
                                                soma = soma + (int.Parse(letras[j].ToString()) * i);

                                            resto = soma % 11;

                                            if (resto >= 10)
                                            {
                                                digito2 = 0;
                                            }
                                            else
                                            {
                                                digito2 = resto;
                                            }
                                            //Verifica se o segundo digito digitado é igual ao que era pra ser:
                                            if (digito2 == int.Parse(letras[10].ToString()))
                                            {
                                                //Se digitos validados, procura na lista de cadastro se já existe o cpf cadastrado:
                                                encontrado = false;
                                                foreach (var passageiro in listPassageiro)
                                                {
                                                    //Se achar na lista não deixa prosseguir
                                                    if (passageiro.Cpf == cpf)
                                                    {
                                                        //Se encontrar na lista, invalida o cadastro
                                                        encontrado = true;
                                                        Console.WriteLine("CPF já cadastrado!");
                                                        retornar = PausaMensagem();
                                                        break; //Quando encontrar um cpf igual na lista, quebra o foreach
                                                    }
                                                    else
                                                        encontrado = false; //Mantem encontrado como false enquanto não achar na lista
                                                }

                                                //Ao fim da procura, se não possuir o cpf na lista, encontrado = false e retorna o cpf cadastrado:
                                                if (encontrado == false)
                                                    //////////RETORNA O CPF
                                                    return cpf;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Esse não é um CPF válido!");
                                                retornar = PausaMensagem();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Esse não é um CPF válido!");
                                            retornar = PausaMensagem();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("CPF com números sequenciais iguais não é válido!");
                                        retornar = PausaMensagem();
                                    }
                                }
                                else
                                {

                                    Console.WriteLine("Só aceita números válidos de 11 digitos");
                                    retornar = PausaMensagem();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Só aceita números válidos de 11 digitos");
                                retornar = PausaMensagem();
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("ERRO: Só aceita números válidos de 11 digitos");
                            retornar = PausaMensagem();
                        }
                    } while (retornar == false);

                    //Retorna nulo se o usuário quiser cancelar no meio do cadastro;
                    return null;

                #endregion;


                case "cnpj":

                    #region CNPJ;

                    do
                    {
                        //Seta encontrado e validado sempre que retorna o laço do processo:
                        encontrado = true; // seta true para não quebrar o for de primeira
                        retornar = false; // só retorna se o usuário quiser
                        qtdnumerosiguais = 0;
                        string cnpj;

                        try
                        {
                            Console.Clear();
                            Console.Write("Informe o CNPJ: ");

                            cnpj = Console.ReadLine();

                            char[] letras = cnpj.ToCharArray();

                            //verifica se tem 14 caracteres:
                            if (letras.Length == 14)
                            {
                                //verifica os 14 caracteres se são obrigatóriamente números:
                                for (int i = 0; i < 14 && encontrado != false; i++)
                                {
                                    foreach (var v in vetornumeros)
                                    {
                                        if (letras[i].ToString().ToUpper().Equals(v))
                                        {
                                            encontrado = true;
                                            break; // sai do foreach e volta pro for
                                        }
                                        else encontrado = false; // se não encontrado, sai do foreach e quebra a condição do for
                                    }
                                }

                                //Qualquer valor que não seja um número invalida o cnpj:
                                if (encontrado == true)
                                {
                                    //Verifica se os números são iguais
                                    for (int i = 0; i < 12; i++)
                                    {
                                        if (letras[i] == letras[i + 1])
                                            qtdnumerosiguais = qtdnumerosiguais + 1;
                                    }

                                    //Se os 12 primeiros digitos forem todos iguais, invalida o cnpj:
                                    if (qtdnumerosiguais != 12)
                                    {
                                        int soma = 0;
                                        int resto = 0;
                                        int digito1 = 0;
                                        int digito2 = 0;

                                        //calcula o primeiro digito verificador do cnpj:
                                        for (int i = 6, j = 0; i < 10; i++, j++)
                                            soma = soma + (int.Parse(letras[j].ToString()) * i);

                                        for (int i = 2, j = 4; i < 10; i++, j++)
                                            soma = soma + (int.Parse(letras[j].ToString()) * i);

                                        resto = soma % 11;

                                        if (resto >= 10)
                                        {
                                            digito1 = 0;

                                        }
                                        else
                                        {
                                            digito1 = resto;
                                        }

                                        //Verifica se o primeiro digito digitado é igual ao que era pra ser:
                                        if (digito1 == int.Parse(letras[12].ToString()))
                                        {
                                            soma = 0; //seta o soma em 0 para o processo de soma do segundo digito do cnpj:

                                            //calcula o segundo digito verificador do cpf:
                                            for (int i = 5, j = 0; i < 10; i++, j++)
                                                soma = soma + (int.Parse(letras[j].ToString()) * i);

                                            for (int i = 2, j = 5; i < 10; i++, j++)
                                                soma = soma + (int.Parse(letras[j].ToString()) * i);

                                            resto = soma % 11;

                                            if (resto >= 10)
                                            {
                                                digito2 = 0;

                                            }
                                            else
                                            {
                                                digito2 = resto;
                                            }
                                            //Verifica se o segundo digito digitado é igual ao que era pra ser:
                                            if (digito2 == int.Parse(letras[13].ToString()))
                                            {
                                                //Se digitos validados, procura na lista de cadastro se já existe o cnpj cadastrado:
                                                encontrado = false;
                                                foreach (var companhia in listCompanhia)
                                                {
                                                    //Se achar na lista não deixa prosseguir
                                                    if (companhia.Cnpj == cnpj)
                                                    {
                                                        //Se encontrar na lista, invalida o cadastro
                                                        encontrado = true;
                                                        Console.WriteLine("CNPJ já cadastrado!");
                                                        retornar = PausaMensagem();
                                                        break; //Quando encontrar um cnpj igual na lista, quebra o foreach
                                                    }
                                                    else
                                                        encontrado = false; //Mantem encontrado como false enquanto não achar na lista
                                                }

                                                //Ao fim da procura, se não possuir o cnpj na lista, encontrado = false e retorna o cnpj cadastrado:
                                                if (encontrado == false)
                                                    //////////RETORNA O CNPJ
                                                    return cnpj;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Esse não é um CNPJ válido!");
                                                retornar = PausaMensagem();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Esse não é um CNPJ válido!");
                                            retornar = PausaMensagem();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("CNPJ com números sequenciais iguais não é válido!");
                                        retornar = PausaMensagem();
                                    }
                                }
                                else
                                {

                                    Console.WriteLine("Só aceita números válidos de 14 digitos");
                                    retornar = PausaMensagem();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Só aceita números válidos de 14 digitos");
                                retornar = PausaMensagem();
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("ERRO: Só aceita números válidos de 14 digitos");
                            retornar = PausaMensagem();
                        }
                    } while (retornar == false);

                    //Retorna nulo se o usuário quiser cancelar no meio do cadastro;
                    return null;

                #endregion;


                case "nome":

                    #region Nome

                    do
                    {
                        string nome;
                        encontrado = true;
                        retornar = false;

                        Console.Write("Informe o Nome completo: ");
                        try
                        {
                            nome = Console.ReadLine();

                            char[] letras = nome.ToCharArray();

                            //Verifica se o nome tem no mínimo 3 e no máximo 50 caracteres:
                            if (letras.Length > 3 && letras.Length <= 50)
                            {
                                //Verifica se o nome só tem letras válidas:
                                for (int i = 0; i < letras.Length && encontrado != false; i++)
                                {
                                    foreach (var v in vetorletras)
                                    {
                                        if (letras[i].ToString().ToUpper().Equals(v))
                                        {
                                            encontrado = true;
                                            break;
                                        }
                                        else encontrado = false;
                                    }
                                }

                                //Se possuir somente letras válidas, prossegue:
                                if (encontrado == true)
                                {
                                    int qtdmax = 50;
                                    int qtdescrito = letras.Length;

                                    //Verifica a quantidade de caracteres que falta para 50 caracteres e preenche de espaço, se preciso:
                                    if (qtdescrito < qtdmax)
                                    {
                                        int qtdfaltante = qtdmax - qtdescrito;

                                        for (int i = 0; i <= qtdfaltante; i++)
                                        {
                                            nome = nome + " ";
                                        }
                                        ///////RETORNA O NOME COM 50 CARACTERES (PREENCHIDO COM ESPAÇOS PARA COMPLETAR 50)
                                        return nome;
                                    }
                                    else
                                    {
                                        ///////RETORNA O NOME COM 50 CARACTERES (SE O USUÁRIO UTILIZAR OS 50 CARACTERES)
                                        return nome;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Nome só aceita letras.");
                                    retornar = PausaMensagem();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nome informado não é válido! Insira o nome completo, máximo 50 caracteres!");
                                retornar = PausaMensagem();
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Insira um valor válido!");
                            retornar = PausaMensagem();
                        }
                    } while (retornar == false);

                    //Retorna nulo se o usuário quiser cancelar no meio do cadastro;
                    return null;

                #endregion


                case "sexo":

                    #region Sexo
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Informe o sexo:\n[M] - Masculino\n[F] - Feminino\n[N] - Não informar");
                        ConsoleKeyInfo op = Console.ReadKey(true);

                        //Verificar se tecla pressionada foi M / F ou N (independente do CAPSLOCK estar ativado!)
                        if (op.Key == ConsoleKey.M)
                        {
                            Console.Clear();
                            return "M";
                        }
                        else
                        {
                            if (op.Key == ConsoleKey.F)
                            {
                                Console.Clear();
                                return "F";
                            }
                            else
                            {
                                if (op.Key == ConsoleKey.N)
                                {
                                    Console.Clear();
                                    return "N";
                                }
                                else
                                {
                                    Console.WriteLine("Escolha uma opção válida!");
                                    retornar = PausaMensagem();
                                }
                            }
                        }
                    } while (retornar == false);

                    //Retorna nulo se o usuário quiser cancelar no meio do cadastro;
                    return null;

                #endregion


                case "datanascimento":

                    #region DataNascimento

                    do
                    {
                        try
                        {
                            ConsoleKeyInfo teclaData;
                            char[] vetortecla;
                            string DataNascimento = null;
                            encontrado = false;
                            string[] vetordata = new string[] { "_", "_", "_", "_", "_", "_", "_", "_" };

                            static void AtualizarTela(string[] vetordata)
                            {
                                Console.Clear();
                                Console.WriteLine("Insira a Data de Nascimento:");
                                Console.WriteLine(vetordata[0] + vetordata[1] + "/" + vetordata[2] + vetordata[3] + "/" + vetordata[4] + vetordata[5] + vetordata[6] + vetordata[7]);
                                Console.CursorVisible = false;
                            }

                            for (int i = 0; i < 8; i++)
                            {
                                AtualizarTela(vetordata);

                                teclaData = Console.ReadKey(true);

                                vetortecla = teclaData.Key.ToString().ToCharArray();

                                if (vetortecla[0] == 'N')
                                {
                                    if (vetornumeros.Contains(vetortecla[6].ToString()) == true)
                                    {
                                        encontrado = true;
                                        vetordata[i] = vetortecla[6].ToString();
                                        DataNascimento = DataNascimento + vetordata[i];
                                    }
                                    else
                                    {
                                        encontrado = false;
                                        break;
                                    }

                                    AtualizarTela(vetordata);
                                }
                                else
                                {

                                    if (vetortecla[0] == 'D')
                                    {
                                        if (vetornumeros.Contains(vetortecla[1].ToString()) == true)
                                        {
                                            encontrado = true;
                                            vetordata[i] = vetortecla[1].ToString();
                                            DataNascimento = DataNascimento + vetordata[i];
                                        }
                                        else
                                        {
                                            encontrado = false;
                                            break;
                                        }

                                        AtualizarTela(vetordata);
                                    }
                                    else
                                    {
                                        encontrado = false;
                                        break;
                                    }
                                }
                            }
                            if (encontrado == true)
                            {
                                if (DateTime.Compare(DateConverter(DataNascimento), System.DateTime.Now) < 0)
                                {
                                    return DataNascimento;
                                }
                                else
                                {
                                    Console.WriteLine("Data de nascimento não aceita datas futuras, insira uma data válida!");
                                    retornar = PausaMensagem();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Por favor, insira uma data válida!");
                                retornar = PausaMensagem();
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Erro: Por favor, insira uma data válida!");
                            retornar = PausaMensagem();
                        }
                    } while (retornar == false);

                    return null;


                #endregion


                case "dataabertura":

                    #region DataAberturaCompanhiaAerea

                    do
                    {
                        try
                        {
                            ConsoleKeyInfo teclaData;
                            char[] vetortecla;
                            string DataAbertura = null;
                            encontrado = false;
                            string[] vetordata = new string[] { "_", "_", "_", "_", "_", "_", "_", "_" };

                            static void AtualizarTela(string[] vetordata)
                            {
                                Console.Clear();
                                Console.WriteLine("Insira a Data de abertura da Empresa:");
                                Console.WriteLine(vetordata[0] + vetordata[1] + "/" + vetordata[2] + vetordata[3] + "/" + vetordata[4] + vetordata[5] + vetordata[6] + vetordata[7]);
                                Console.CursorVisible = false;
                            }

                            //Verificar se digitou só nrs válidos
                            for (int i = 0; i < 8; i++)
                            {
                                AtualizarTela(vetordata);

                                teclaData = Console.ReadKey(true);

                                vetortecla = teclaData.Key.ToString().ToCharArray();

                                if (vetortecla[0] == 'N')
                                {
                                    if (vetornumeros.Contains(vetortecla[6].ToString()) == true)
                                    {
                                        encontrado = true;
                                        vetordata[i] = vetortecla[6].ToString();
                                        DataAbertura = DataAbertura + vetordata[i];
                                    }
                                    else
                                    {
                                        encontrado = false;
                                        break;
                                    }

                                    AtualizarTela(vetordata);
                                }
                                else
                                {
                                    if (vetortecla[0] == 'D')
                                    {
                                        if (vetornumeros.Contains(vetortecla[1].ToString()) == true)
                                        {
                                            encontrado = true;
                                            vetordata[i] = vetortecla[1].ToString();
                                            DataAbertura = DataAbertura + vetordata[i];
                                        }
                                        else
                                        {
                                            encontrado = false;
                                            break;
                                        }

                                        AtualizarTela(vetordata);
                                    }
                                    else
                                    {
                                        encontrado = false;
                                        break;
                                    }
                                }
                            }
                            //Se só digitou números válidos, continua:
                            if (encontrado == true)
                            {
                                //Verificar se é data futura:
                                if (DateTime.Compare(DateConverter(DataAbertura), System.DateTime.Now) < 0)
                                {
                                    //Verificar se a abertura da empresa é maior que 6 meses:
                                    if (DateTime.Compare(DateConverter(DataAbertura), System.DateTime.Now.AddMonths(-6)) < 0)
                                    {
                                        ///////RETORNA A DATA DE ABERTURA
                                        return DataAbertura;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\nO Aeroporto não aceita cadastrar companhia aérea com menos de 6 meses de existência.");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("\nVocê será redirecionado para o menu anterior.");
                                        Pausa();

                                        //Retorna nullo direto, não tem a opção de digitar a data novamente
                                        return null;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Não aceita datas futuras, insira uma data válida!");
                                    retornar = PausaMensagem();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Por favor, insira uma data válida!");
                                retornar = PausaMensagem();
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Erro: Por favor, insira uma data válida!");
                            retornar = PausaMensagem();
                        }
                    } while (retornar == false);

                    return null;
                case "idaeronave":
                    #region IdAeronave
                    //Os prefixos de nacionalidade que identificam aeronaves privadas e comerciais do Brasil são PT, PR, PP, PS e PH.
                    string[] prefixoaeronave = new string[] { "PT", "PR", "PP", "PS", "PH" };
                    //A Agência Nacional de Aviação Civil(Anac) proíbe o registro de marcas de identificação em aeronaves iniciadas com a letra Q
                    //ou que tenham W como segunda letra.Os arranjos SOS, XXX, PAN, TTT, VFR, IFR, VMC e IMC não podem ser utilizados.
                    string[] idproibido = new string[] { "SOS", "XXX", "PAN", "TTT", "VFR", "IFR", "VMC", "IMC" };
                    string idaeronave;
                    do
                    {
                        Console.Write("Informe o código Nacional de identificação da Aeronave: ");
                        try
                        {
                            idaeronave = Console.ReadLine().ToUpper();
                            char[] letras = idaeronave.ToCharArray();
                            //Verifica se tem 6 caracteres obrigatoriamente:
                            if (letras.Length == 6)
                            {
                                //verifica se foi inserido o traço - na inscrição:
                                if (letras[2] == '-')
                                {
                                    //Verifica se tem Q e W onde não pode na matrícula da aeronave:
                                    if (letras[3] != 'Q' && letras[4] != 'W')
                                    {
                                        //Separa a escrita depois do traço, referente à matrícula do avião:
                                        string matriculaaviao = letras[3].ToString() + letras[4].ToString() + letras[5].ToString();
                                        //Verifica se a matrícula possui um nome proibido, contido no vetor idproibido;
                                        if (idproibido.Contains(matriculaaviao) == false)
                                        {
                                            //Separa os 2 primeiros prefixos e guarda na variável prefixoaviao:
                                            string prefixoaviao = letras[0].ToString() + letras[1].ToString();
                                            //Verifica se os 2 primeiros prefixos são válidos:
                                            if (prefixoaeronave.Contains(prefixoaviao) == true)
                                            {
                                                return idaeronave;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Os prefixos devem ser obrigatóriamente PT ou PR ou PP ou PS ou PH ");
                                                retornar = PausaMensagem();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("As matrículas SOS, XXX, PAN, TTT, VFR, IFR, VMC e IMC não podem ser utilizadas");
                                            retornar = PausaMensagem();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Não é permitido a letra Q como primeira letra e nem a letra W como segunda letra da matrícula da aeronave");
                                        retornar = PausaMensagem();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Digite obrigatóriamente o traço - após prefixos de nacionalidade");
                                    retornar = PausaMensagem();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Quantidade incorreta de dígitos de identificação");
                                retornar = PausaMensagem();
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Insira um valor válido!");
                            retornar = PausaMensagem();
                        }
                    } while (retornar == false);
                    //Retorna nulo se o usuário quiser cancelar no meio do cadastro;
                    return null;
                #endregion


                #endregion


                case "datavoo":

                    #region DataVoo

                    do
                    {
                        try
                        {
                            ConsoleKeyInfo teclaData;
                            char[] vetortecla;
                            string DataVoo = null;
                            encontrado = false;
                            string[] vetordata = new string[] { "_", "_", "_", "_", "_", "_", "_", "_", " ", "_", "_", "_", "_" };

                            static void AtualizarTela(string[] vetordata)
                            {
                                Console.Clear();
                                Console.WriteLine("Insira a Data e hora do Voo:");
                                Console.WriteLine(vetordata[0] + vetordata[1] + "/" + vetordata[2] + vetordata[3] + "/" + vetordata[4] + vetordata[5] + vetordata[6] + vetordata[7] + " " + vetordata[9] + vetordata[10] + ":" + vetordata[11] + vetordata[12]);
                                Console.CursorVisible = false;
                            }


                            for (int i = 0; i < 8; i++)
                            {
                                AtualizarTela(vetordata);

                                teclaData = Console.ReadKey(true);

                                vetortecla = teclaData.Key.ToString().ToCharArray();

                                //Verifica se foi teclado realmente um número:
                                if (vetortecla[0] == 'N')
                                {
                                    if (vetornumeros.Contains(vetortecla[6].ToString()) == true)
                                    {
                                        encontrado = true;
                                        vetordata[i] = vetortecla[6].ToString();
                                        DataVoo = DataVoo + vetordata[i];
                                    }
                                    else
                                    {
                                        encontrado = false;
                                        break;
                                    }

                                    AtualizarTela(vetordata);
                                }
                                else
                                {
                                    if (vetortecla[0] == 'D')
                                    {
                                        if (vetornumeros.Contains(vetortecla[1].ToString()) == true)
                                        {
                                            encontrado = true;
                                            vetordata[i] = vetortecla[1].ToString();
                                            DataVoo = DataVoo + vetordata[i];
                                        }
                                        else
                                        {
                                            encontrado = false;
                                            break;
                                        }

                                        AtualizarTela(vetordata);
                                    }
                                    else
                                    {
                                        encontrado = false;
                                        break;
                                    }
                                }
                            }

                            //Se todas entradas foram números válidos, continua:
                            //A variável DataVoo nesse instante só tem datas sem barras, ex: "12345678":
                            if (encontrado == true)
                            {
                                //Pede os dados da hora separado da data:
                                for (int i = 9; i < 13; i++)
                                {
                                    AtualizarTela(vetordata);

                                    teclaData = Console.ReadKey(true);

                                    vetortecla = teclaData.Key.ToString().ToCharArray();

                                    //Verifica se foi teclado realmente um número:
                                    if (vetortecla[0] == 'N')
                                    {
                                        if (vetornumeros.Contains(vetortecla[6].ToString()) == true)
                                        {
                                            encontrado = true;
                                            vetordata[i] = vetortecla[6].ToString();
                                            DataVoo = DataVoo + vetordata[i];
                                        }
                                        else
                                        {
                                            encontrado = false;
                                            break;
                                        }

                                        AtualizarTela(vetordata);
                                    }
                                    else
                                    {
                                        if (vetortecla[0] == 'D')
                                        {
                                            if (vetornumeros.Contains(vetortecla[1].ToString()) == true)
                                            {
                                                encontrado = true;
                                                vetordata[i] = vetortecla[1].ToString();
                                                DataVoo = DataVoo + vetordata[i];
                                            }
                                            else
                                            {
                                                encontrado = false;
                                                break;
                                            }

                                            AtualizarTela(vetordata);
                                        }
                                    }
                                }

                                //Se dados da hora forem válidos, continua:
                                //A variável DataVoo nesse instante tem a data e a hora sem formatação, ex: "123456781234":
                                if (encontrado == true)
                                {
                                    //Verifica se a data de cadastro do voo não é data antiga:
                                    if (DateTime.Compare(DateHourConverter(DataVoo), System.DateTime.Now) > 0)
                                    {
                                        //////RETORNA A DATA DO VOO "123456781234"
                                        return DataVoo;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Não é possível agendar voo em datas passadas!");
                                        retornar = PausaMensagem();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Insira uma hora válida!");
                                    retornar = PausaMensagem();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Por favor, insira uma data válida!");
                                retornar = PausaMensagem();
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Erro: Por favor, insira uma data válida!");
                            retornar = PausaMensagem();
                        }
                    } while (retornar == false);


                    return null;

                #endregion


                default: return null;

            }
        }
        #endregion

        #region TELAS Principais
        static void TelaInicial() // INCOMPLETO 
        {
            int opc = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Bem vindo à On The Fly!");
                Console.WriteLine("\nPor Favor, informe a Opção Desejada:\n");
                Console.WriteLine(" 1 - Acesso aos Cadastros de Companhias Aéreas\n");
                Console.WriteLine(" 2 - Acesso aos Cadastros de Passageiros\n");
                Console.WriteLine(" 3 - Acesso às Vendas de Passagens\n");
                Console.WriteLine(" 4 - Acesso a Lista de CPF Restritos\n");
                Console.WriteLine(" 5 - Acesso a Lista de CNPJ Restritos");
                Console.WriteLine("\n 0 - Encerrar Sessão\n");
                opc = int.Parse(ValidarEntrada("menu"));
                Console.Clear();

                switch (opc)
                {
                    case 0:

                        // Lembrar de colocar uma chamada para todas funções de salvar antes.
                        Console.WriteLine("Encerrando...");
                        Environment.Exit(0); //Fecha o programa 

                        break;

                    case 1:

                        // Chamar a tela de Companhias Aereas
                        TelaInicialCompanhiasAereas();

                        break;

                    case 2:

                        // Chamar a tela de passageiros
                        TelaInicialPassageiros();
                        break;

                    case 3:

                        // Chamar a tela de entrada para as vendas

                        break;

                    case 4:

                        // Chamar a tela para ver os CPF's Restritos
                        TelaInicialCpfRestritos();

                        break;

                    case 5:

                        // Chamar a tela para ver os CNPJ's Restritos
                        TelaInicialCnpjRestritos();

                        break;
                }

            } while (opc != 0);

        }

        #region TELAS_PASSAGEIROS
        static void TelaInicialPassageiros() //OK ~ Falta Acertar o uso das funções *  
        {
            int opc = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("\nInforme a Opção Desejada:\n");
                Console.WriteLine(" 1 - Passageiro já cadastrado\n");
                Console.WriteLine(" 2 - Cadastrar um novo Passageiro\n");
                Console.WriteLine("\n 0 - SAIR\n");

                opc = int.Parse(ValidarEntrada("menu"));
                Console.Clear();

                switch (opc)
                {
                    case 0:
                        TelaInicial();
                        break;

                    case 1:
                        TelaLoginPassageiro();
                        break;

                    case 2:
                        TelaCadastrarPassageiro();
                        break;
                }

            } while (opc != 0);
        }

        static void TelaLoginPassageiro() // OK ~ Falta Acertar o uso das funções e liberar as partes comentadas * 
        {
            Passageiro passageiroAtivo;
            Console.Clear();
            Console.WriteLine("\nInforme o 'CPF' para Entrar:\n");
         //     passageiroAtivo = ValidarEntrada("cpfexiste");
         //    if (passageiroAtivo == null)
          //   {
           //   Pausa();
           //  TelaInicialPassageiros();
           //   }

            //  TelaOpcoesPassageiro(passageiroAtivo); // encontrou um 'CPF' valido e existente nos cadastros, então manda para a tela de opções.
        }

        static void TelaOpcoesPassageiro(Passageiro passageiroAtivo) // OK ~ Falta Acertar o uso das funções e liberar as partes comentadas * 
        {
            int opc;
            do
            {
                Console.Clear();
                Console.WriteLine("\nOPÇÕES PARA O PASSAGEIRO: " /* + passageiroAtivo.Nome*/);
                Console.WriteLine("\nEscolha a Opção Desejada:\n");
                Console.WriteLine(" 1 - Editar Cadastro\n");
                Console.WriteLine(" 2 - Comprar Passagem\n");
                Console.WriteLine("\n 0 - SAIR\n");
                opc = int.Parse(ValidarEntrada("menu"));
                Console.Clear();

                switch (opc)
                {
                    case 0:

                        TelaInicialPassageiros(); // escolheu sair, volta para a tela inicial de passageiros

                        break;

                    case 1:

                        TelaEditarPassageiro(passageiroAtivo); // abre os dados do passageiro em questão para escolher quais quer editar

                        break;

                    case 2:

                        // bool restrito = false;
                        //   bool maiorDe18 = false;
                        //string cpf = passageiroAtivo.Cpf;
                        // DateTime nascimento = passageiroAtivo.DataNascimento;

                        // maiorDe18 = VerificarMaiorDe18(nascimento);
                        // if (maiorDe18 == false)
                        // {
                        //      Console.Clear();
                        //      Console.WriteLine("\nImpossível acessar Area de Vendas com Passageiro menor de 18 anos!");
                        //      Pausa();
                        //      TelaOpcoesPassageiro(passageiroAtivo);
                        // }
                        // 
                        // restrito = VerificarCpfRestrito("cpf");
                        // if (restrito == false)
                        // {
                        //      Console.Clear();
                        //      Console.WriteLine("\nAcesso à area de Vendas está 'RESTRITA' para esse 'CPF'!");
                        //      Pausa();
                        //      TelaOpcoesPassageiro(passageiroAtivo);
                        // }

                        // if (restrito == true && maiorDe18 == true)
                        //{
                        //      TelaInicialVendas();
                        //}

                        break;
                }

            } while (true);
            // case 2:
            //
            // validar se o Passageiro com esse CPF é maior de 18 anos
            //
            // validar se o CPF está na lista de bloqueados
            //
            // se as duas condições acima forem verdadeiras (é maior de 18 e não está na lista de bloqueados)
            // segue para as vendas ||| se uma das duas não for verdadeira retornara para tela anterior depois de uma mensagem com o motivo.
        }

        static void TelaCadastrarPassageiro() // OK ! Só dar um 'CTRL+K+U' em tudo pra tirar os comentarios 
        {
            do
            {
                string nome, cpf;
                string dataNascimento;
                char sexo;

                Passageiro novoPassageiro;

                nome = ValidarEntrada("nome");
                if (nome == null) TelaInicialPassageiros();

                cpf = ValidarEntrada("cpf");   /// OBS: Precisa validar se o 'CPF' já existe na lista de cadastros!
                if (cpf == null) TelaInicialPassageiros();

                dataNascimento = ValidarEntrada("datanascimento");
                if (dataNascimento == null) TelaInicialPassageiros();

                sexo = char.Parse(ValidarEntrada("sexo"));
                if (sexo.Equals(null)) TelaInicialPassageiros();

                Console.WriteLine("\nPassageiro Cadastrado com Sucesso!");
                Passageiro passageiro = new Passageiro(cpf, nome, DateConverter(dataNascimento), sexo, System.DateTime.Now, System.DateTime.Now, 'A');
                listPassageiro.Add(passageiro);
                GravarPassageiro(listPassageiro);
                Pausa();
                TelaInicialPassageiros();

            } while (true);
        }

        static void TelaEditarPassageiro(Passageiro passageiroAtivo) // OK ~ Falta Acertar o uso das funções e liberar as partes comentadas * 
        {
            int opc;
            string novoNome;
            string novaDataNascimento;
            DateTime data;
            char novoSexo;
            char novaSituacao;

            do
            {
                Console.Clear();
                Console.WriteLine("\nEDTAR DADOS");
                Console.WriteLine("\nEscolha qual Dado deseja Editar: ");
                Console.Write("\n 1 - Nome");
                Console.Write("\n 2 - Data de Nascimento");
                Console.Write("\n 3 - Sexo");
                Console.Write("\n 4 - Situação (Ativo / Inativo");
                Console.Write("\n 0 - Voltar");

                opc = int.Parse(ValidarEntrada("menu"));
                Console.Clear();

                switch (opc)
                {
                    case 0:

                        TelaOpcoesPassageiro(passageiroAtivo);

                        break;

                    case 1:

                        Console.Clear();
                        Console.WriteLine("\nNome Atual: " + passageiroAtivo.Nome);
                        Console.Write("\n\nInforme o Novo Nome");
                        Pausa();
                        novoNome = ValidarEntrada("nome");
                        if (novoNome == null) TelaEditarPassageiro(passageiroAtivo);

                        passageiroAtivo.Nome = novoNome;
                        Console.Clear();
                        Console.WriteLine("\nNome Alterado com Sucesso!");
                        Pausa();
                        TelaEditarPassageiro(passageiroAtivo);

                        break;

                    case 2:

                        Console.Clear();
                        Console.WriteLine("\nData de nascimento Atual: " + passageiroAtivo.DataNascimento.ToShortDateString());
                        Console.Write("\n\nInforme a Nova Data de Nascimento");
                        Pausa();
                        novaDataNascimento = ValidarEntrada("datanascimento");
                        if (novaDataNascimento == null) TelaEditarPassageiro(passageiroAtivo);
                        data = DateConverter(novaDataNascimento);
                        passageiroAtivo.DataNascimento = data;
                        Console.Clear();
                        Console.WriteLine("\nData de Nascimento Alterada com Sucesso!");
                        Pausa();
                        TelaEditarPassageiro(passageiroAtivo);

                        break;

                    case 3:

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("\nSexo Atual: " + passageiroAtivo.Sexo);
                            Console.Write("\n\nInforme o Novo Sexo");
                            Pausa();
                            novoSexo = char.Parse(ValidarEntrada("sexo"));
                            if (novoSexo.Equals(null)) TelaInicialPassageiros();
                            passageiroAtivo.Sexo = novoSexo;
                            Console.Clear();
                            Console.WriteLine("\nSexo Alterado com Sucesso!");
                            Pausa();
                            TelaEditarPassageiro(passageiroAtivo);
                        } while (true);

                    case 4:

                        Console.Clear();
                        Console.WriteLine("\nPASSAGEIRO: " /*passageiroAtivo.Nome*/);
                        //if (passageiroAtivo.Situacao == 'A')
                        { Console.WriteLine("\nSituação Atual: ATIVO"); }
                        //if (passageiroAtivo.Situacao == 'I')
                        { Console.WriteLine("\nSituação Atual: INATIVO"); }
                        Pausa();

                        //novaSituacao = char.Parse(ValidarEntrada("situacao"));
                        //if (novaSituacao.Equals(null)) TelaInicialPassageiros();

                        //passageiroAtivo.Situacao = novaSituacao;
                        Console.Clear();
                        Console.WriteLine("\nSituação de Cadastro Alterada com Sucesso!");
                        Pausa();
                        TelaEditarPassageiro(passageiroAtivo);
                        break;
                }

            } while (true);
        }

        #endregion

        #region TELAS_ARQUIVOS_BLOQUEADOS
        static void TelaInicialCpfRestritos() //    OK
        {
            int opc = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("\n'CPF' RESTRITOS");
                Console.WriteLine("\nInforme a Opção Desejada:\n");
                Console.WriteLine(" 1 - Ver a Lista de 'CPF' Restritos\n");
                Console.WriteLine(" 2 - Adicionar um 'CPF' à Lista de Restritos\n");
                Console.WriteLine(" 3 - Remover um 'CPF' da Lista de Restritos\n");
                Console.WriteLine("\n 0 - Sair\n");

                opc = int.Parse(ValidarEntrada("menu"));

                switch (opc)
                {
                    case 0:

                        TelaInicial();

                        break;

                    case 1:
                        Console.Clear();

                        foreach (var passageiro in listRestritos)
                        {
                            if (listRestritos.Count == 0)
                            {
                                Console.WriteLine("LISTA VAZIA, IMPOSSÍVEL IMPRIMIR!");
                                Pausa();
                                TelaInicialCpfRestritos();

                            }
                            else
                            {
                                foreach (var cpfRest in listRestritos)
                                {
                                    Console.WriteLine(cpfRest);
                                }
                                Console.WriteLine("Impressão realizada com sucesso!");
                                Pausa();
                                TelaInicialCpfRestritos();
                            }
                        }
                        break;

                    case 2:
                        Console.Clear();
                        string adcCpf = ValidarEntrada("cpf");
                        listRestritos.Add(adcCpf);
                        Console.Clear();
                        Console.WriteLine("Cpf adiconado com sucesso");
                        Pausa();
                        TelaInicialCpfRestritos();

                        break;

                    case 3:
                        Console.Clear();
                        string Cpf = ValidarEntrada("cpf");
                        bool achei = false;

                        foreach (var passageiro in listRestritos)
                        {
                            if (listRestritos.Count == 0)
                            {
                                Console.WriteLine("LISTA VAZIA, IMPOSSÍVEL REMOVER!");
                                Console.ReadKey();
                                TelaInicialCpfRestritos();
                            }
                            else
                            {

                                foreach (var cpfRestrito in listRestritos)
                                {
                                    if (cpfRestrito == Cpf)
                                    {
                                        achei = true;
                                        listRestritos.Remove(cpfRestrito);
                                        Console.WriteLine("Cpf Removido com sucesso!");
                                        Pausa();
                                        TelaInicialCpfRestritos();
                                    }
                                }
                                if (achei)
                                {
                                    Console.WriteLine(Cpf + " não encontrado!");
                                    Pausa();
                                    TelaInicialCpfRestritos();
                                }

                            }
                        }

                        break;
                }

            } while (true);
        }
        static void TelaInicialCnpjRestritos() // OK
        {
            int opc = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("\n'CNPJ' RESTRITOS");
                Console.WriteLine("\nInforme a Opção Desejada:\n");
                Console.WriteLine(" 1 - Ver a Lista de 'CNPJ' Restritos\n");
                Console.WriteLine(" 2 - Adicionar um 'CNPJ' à Lista de Restritos\n");
                Console.WriteLine(" 3 - Remover um 'CNPJ' da Lista de Restritos\n");
                Console.WriteLine("\n 0 - Sair\n");

                opc = int.Parse(ValidarEntrada("menu"));

                switch (opc)
                {
                    case 0:

                        TelaInicial();
                        break;

                    case 1:
                        //imprimo lista de bloqueados
                        foreach (var companhiaAerea in listBloqueados)
                        {
                            if (listBloqueados.Count == 0)
                            {
                                Console.WriteLine("LISTA VAZIA, IMPOSSÍVEL IMPRIMIR!");
                                Pausa();
                                TelaInicialCnpjRestritos();
                            }
                            else
                            {
                                foreach (var cnpjRest in listRestritos)
                                {
                                    Console.WriteLine(cnpjRest);
                                }
                                Console.WriteLine("Impressão realizada com sucesso!");
                                Pausa();
                                TelaInicialCnpjRestritos();
                            }
                        }
                        break;

                    case 2:
                        //adiciono lista de bloqueados
                        Console.Clear();
                        string adcCnpj = ValidarEntrada("cnpj");
                        listRestritos.Add(adcCnpj);
                        Console.WriteLine("Cnpj adiconado com sucesso");
                        Pausa();
                        TelaInicialCnpjRestritos();
                        break;

                    case 3:
                        //busco determinado cnpj na lista de bloqueados para remover
                        Console.Clear();
                        string Cnpj = ValidarEntrada("cnpj");
                        bool achei = false;
                        foreach (var CompanhiaAerea in listBloqueados)
                        {
                            if (listBloqueados.Count == 0)
                            {
                                Console.WriteLine("LISTA VAZIA, IMPOSSÍVEL REMOVER!");
                                Console.ReadKey();
                                TelaInicialCnpjRestritos();
                            }
                            else
                            {

                                foreach (var cnpjBloqueados in listRestritos)
                                {
                                    if (cnpjBloqueados == Cnpj)
                                    {
                                        achei = true;
                                        listRestritos.Remove(cnpjBloqueados);
                                        Console.WriteLine("Cnpj Removido com sucesso!");
                                        Pausa();
                                        TelaInicialCnpjRestritos();
                                    }
                                }
                                if (achei)
                                {
                                    Console.WriteLine(Cnpj + " não encontrado!");
                                    Pausa();
                                    TelaInicialCnpjRestritos();
                                }

                            }
                        }
                        break;
                }

            } while (true);
        }
        #endregion  //OK //OK

        #region TELAS_COMPANHIAS_AEREAS
        static void TelaInicialCompanhiasAereas() // OK
        {
            int opc = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("\nInforme a Opção Desejada:\n");
                Console.WriteLine(" 1 - Companhia Aéria já cadastrada\n");
                Console.WriteLine(" 2 - Cadastrar uma Nova Companhia Aérea\n");
                Console.WriteLine("\n 0 - SAIR\n");

                opc = int.Parse(ValidarEntrada("menu"));

                switch (opc)
                {
                    case 0:

                        TelaInicial();

                        break;

                    case 1:

                        TelaLoginCompanhiaAerea();

                        break;

                    case 2:

                        TelaCadastrarCompanhiaAerea();

                        break;
                }

            } while (opc != 0);
        }

        static void TelaLoginCompanhiaAerea() // OK ~ Falta Acertar o uso das funções e liberar as partes comentadas *
        {
            CompanhiaAerea compAtivo;
            Console.Clear();
            Console.WriteLine("\nInforme o 'CNPJ' para Entrar:\n");
            /*  compAtivo = ValidarLoginCompanhiaAerea();
              if (compAtivo == null)
               {
                    Pausa();
                   TelaInicialPassageiro();
               }

              TelaOpcoesCompanhiaAerea(compAtivo); // encontrou um 'CNPJ' valido e existente nos cadastros, então manda para a tela de opções
          */
        }
        static void TelaCadastrarCompanhiaAerea()
        {

        }
        static void TelaOpcoesCompanhiaAerea(/*CompanhiaAerea compAtivo*/)
        {

        }
        #endregion
        #endregion  //Incompleto

        #region TelasVenda
        static void TelaVendas(Passageiro passageiroAtivo,string IDPassagem, Voo vooatual, int quantPassagem) //VER OS PARAMETROS
        {
            quantPassagem = 0;
            int opc;
            Console.WriteLine("Informe a opção desejada: \n");
            Console.WriteLine("1 - Vender Passagem\n");
            Console.WriteLine("2 - Ver Passagens Vendidas\n");
            Console.WriteLine("3 - Ver Passagens Reservadas\n");
            Console.WriteLine("\n0 -  SAIR\n");
            Console.WriteLine("\nOpção: ");
            opc = int.Parse(Console.ReadLine());
            switch (opc)
            {
                case 0:
                    //Retorna para tela:
                    TelaOpcoesPassageiro(passageiroAtivo);
                    break;
                case 1:
                    TelaVoosDisponiveis();
                    break;
                case 2:
                    TelaPassagensVendidas();
                    break;
                case 3:
                    TelaPassagensReservadas();
                    break;
            }
        }
        static void TelaVoosDisponiveis() // VER OS PARAMETROS
        {
            int opc;
            foreach (var Voo in listVoo)
            {
                if (Voo.Situacao == 'A')
                {
                    Console.WriteLine("\nIDVoo: " + Voo.IDVoo + "\nDestino: " + Voo.Destino + "\nData do Voo: " + Voo.DataVoo);
                }
            }
            Console.WriteLine("\n----------------------------------------------------------------------------------------------");
            Console.WriteLine("\n1 - Escolher o Voo Desejado: ");
            Console.WriteLine("0 - Voltar");
            opc = int.Parse(ValidarEntrada("menu"));
            switch (opc)
            {
                case 0:
                    //TelaVendas(passageiroAtivo, IDPassagem, vooatual, quantPassagem);
                    break;
                case 1:
                    Console.Clear();
                    string idvoo = ValidarEntrada("idvoo");
                    if (idvoo == null) TelaVoosDisponiveis();
                  //  TelaDescricaoVoo(idvoo);
                    break;
            }
        } // VER OS PARAMETROS
        static void TelaDescricaoVoo(string idvoo)
        {
            Voo vooatual = null;
            foreach (var voo in listVoo)
            {
                if (voo.IDVoo == idvoo)
                {
                    vooatual = voo;
                
                    break;
                }
                else
                {
                    vooatual = null;
                }
            }
            Console.WriteLine(vooatual.ToString());
        }
        static void TelaPassagensVendidas()
        {

        }
        static void TelaPassagensReservadas( )
        {
            int opc;//mostro a lista de passagens reservadas
            foreach (var PassagemVoo in listPassagem)
            {
                if (PassagemVoo.Situacao == 'R')
                {
                  //  Console.WriteLine("\nID Passagem: " + PassagemVoo.IDPassagem + "\nID Voo: " + vooatual.IDVoo + "\nValor: " + PassagemVoo.Valor+"\nData da Venda: "+PassagemVoo.DataUltimaOperacao);
                }
            }
            Console.WriteLine("\n----------------------------------------------------------------------------------------------");
            Console.WriteLine("\n1 - Escolher a Passagem Reservada Desejada: ");
            Console.WriteLine("0 - Voltar");
            opc = int.Parse(ValidarEntrada("menu"));
            switch (opc)
            {
                case 0:
                   // TelaVendas(passageiroAtivo, IDPassagem, vooatual, quantPassagem);
                    break;
                case 1:
                  /*  if (quantPassagem >= 0 && quantPassagem < 4)
                    {
                        Console.Clear();
                        string idPassagem = ValidarEntrada("idpassagem");
                        if (idPassagem == null) TelaPassagensReservadas(IDPassagem, vooatual, passageiroAtivo, quantPassagem);
                       
                        DescricaoReservada(IDPassagem, passageiroAtivo,quantPassagem, vooatual);
                      
                    }
                    else
                    {
                        Console.WriteLine("Você atingiu o máximo de passagens por venda(4)");
                        Pausa();
                      //  TelaVendas(IDPassagem, vooatual, passageiroAtivo, quantPassagem);
                    }
                  */
                    break;
            }

        }
        static void DescricaoReservada(string IDPassagem)
        {
            PassagemVoo passagemAtual = null;
            foreach (var passagem in listPassagem)
            {
                if (passagem.IDPassagem == IDPassagem)
                {
                    passagemAtual = passagem;
                    break;
                }
                else
                {
                    passagemAtual = null;
                }
            }
            Console.WriteLine(passagemAtual.ToString());
          //  PagarOuLivre();
        }
        static void PagarOuLivre()
        {
            int opc = 0;
            Console.WriteLine("\n0 - Voltar");
            Console.WriteLine("\n1- Efetuar pagamento passagem");
            Console.WriteLine("\n2- Cancelar reserva passagem");
            opc = int.Parse(ValidarEntrada("menu"));
            switch (opc)
            {
                case 0:
                   // TelaOpcoesPassageiro(passageiroAtivo);
                    break;
                case 1:
                   // passagemAtual.Situacao = 'P';// se pagar a reserva, a passagem fica paga.
                  //  quantPassagem += 1;
                  //  passagemAtual.ToString();// histórico da passagem
                  //  TelaVendas(IDPassagem,vooatual,passageiroAtivo,quantPassagem);
                    break;
                case 2:
                  //  passagemAtual.Situacao = 'L';// se cancela a reserva, a passagem fica livre
                    break;
            }
        }
        #endregion

        static void Main(string[] args)
        {
            System.IO.Directory.CreateDirectory(@"C:\DBOnTheFly");
            CarregarArquivos();
            Pausa();
            TelaInicial();
        }
    }
}
