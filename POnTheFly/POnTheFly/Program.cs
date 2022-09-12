using Proj_POG_OnTheFly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace POnTheFly
{
    internal class Program
    {
        static List<Passageiro> listPassageiro = new List<Passageiro>();
        static List<CompanhiaAerea> listCompanhiaAerea = new List<CompanhiaAerea>();
        static List<Aeronave> listAeronave = new List<Aeronave>();
        static List<Voo> listVoo = new List<Voo>();
        static List<PassagemVoo> listPassagemVoo = new List<PassagemVoo>();
        static List<Venda> listVenda = new List<Venda>();
        static List<ItemVenda> listItemVenda = new List<ItemVenda>();
        static List<string> listRestritos = new List<string>();
        static List<string> listBloqueados = new List<string>();
        static List<string> listDestino = new List<string>();
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
                DataUltimaCompra = DateTime.Parse(data);
                for (int i = 83; i <= 94; i++)
                {
                    data = data + caracteres[i].ToString();
                }
                DataCadastro = DateConverter(data);
                Situacao = caracteres[95];

                Passageiro P = new Passageiro(cpf, nome, DataNascimento, Sexo, DataUltimaCompra, DataCadastro, Situacao);
                listPassageiro.Add(P);
            }
            //Companhia Aerea
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
                UltimoVoo = DateConverter(data);
                for (int i = 84; i <= 95; i++)
                {
                    data = data + caracteres[i].ToString();
                }
                DataCadastro = DateConverter(data);
                Situacao = caracteres[96];
                CompanhiaAerea CA = new CompanhiaAerea(Cnpj, RazaoSocial, DataAbertura, UltimoVoo, DataCadastro, Situacao);
                listCompanhiaAerea.Add(CA);
            }
            //Aeronaves
            linhas = System.IO.File.ReadAllLines(@"C:\DBOnTheFly\Aeronaves.dat");
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
                UltimaVenda = DateConverter(data);
                for (int i = 24; i <= 35; i++)
                {
                    data = data + caracteres[i].ToString();
                }
                DataCadastro = DateConverter(data);
                Situacao = caracteres[36];
                Aeronave Aer = new Aeronave(Inscricao, Capacidade, Assentos, UltimaVenda, DataCadastro, Situacao);
                listAeronave.Add(Aer);
            }
            //Voo
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
                DataVoo = DateConverter(data);
                for (int i = 26; i <= 37; i++)
                {
                    data = data + caracteres[i].ToString();
                }
                DataCadastro = DateConverter(data);
                Situacao = caracteres[38];
                Voo V = new Voo(IDVoo, Destino, Aeronave, DataVoo, DataCadastro, Situacao);
                listVoo.Add(V);
            }
            //PassagemVoo
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
                DataUltimaOperacao = DateConverter(data);
                for (int i = 22; i <= 28; i++)
                {
                    valor = valor + caracteres[i].ToString();
                }
                Valor = float.Parse(valor);
                Situacao = caracteres[29];
                PassagemVoo PV = new PassagemVoo(IDPassagem, IDVoo, DataUltimaOperacao, Valor, Situacao);
                listPassagemVoo.Add(PV);
            }
            //Venda
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
                DataVenda = DateConverter(data);
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
            //ItemVenda
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
            //Restritos
            linhas = System.IO.File.ReadAllLines(@"C:\DBOnTheFly\Restritos.dat");
            foreach (var linha in linhas)
            {
                caracteres = linha.ToCharArray();
                for (int i = 0; i < 10; i++)
                {
                    cpf = cpf + caracteres[i].ToString();
                }
            }
            //Bloqueados
            linhas = System.IO.File.ReadAllLines(@"C:\DBOnTheFly\Bloqueados.dat");
            foreach (var linha in linhas)
            {
                caracteres = linha.ToCharArray();
                for (int i = 0; i < 13; i++)
                {
                    Cnpj = Cnpj + caracteres[i].ToString();
                }
            }
        }
        #endregion GravarCarregar

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

        static public string ValidarEntrada(string entrada)
        {
            string[] vetorletras = new string[] {"F","Ç","ç","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S",
            "T","U","V","W","X","Y","Z","Á","É","Í","Ó","Ú","À","È","Ì","Ò","Ù","Â","Ê","Î","Ô","Û","Ã","Õ"," "};

            string[] vetornumeros = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            //string[] vetormenu = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };

            bool encontrado;



            bool retornar = true;
            int qtdnumerosiguais = 0;

            switch (entrada)
            {

              /*  case "menu":

                    #region Menu

                    do
                    {
                        string menu;
                        try
                        {
                            menu = Console.ReadLine();
                            return menu;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Digite uma opção válida!");
                            return null;
                        }

                        return null;

                        #endregion

                */
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
                                                foreach (var companhia in listCompanhiaAerea)
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

                                        for (int i = 1; i < qtdfaltante; i++)
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
                            //List<string> datanumeros = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

                            static void AtualizarTela(int i, string[] vetordata)
                            {
                                Console.Clear();
                                Console.WriteLine("Insira a Data de Nascimento:");
                                Console.WriteLine(vetordata[0] + vetordata[1] + "/" + vetordata[2] + vetordata[3] + "/" + vetordata[4] + vetordata[5] + vetordata[6] + vetordata[7]);
                                Console.CursorVisible = false;
                            }

                            for (int i = 0; i < 8; i++)
                            {
                                AtualizarTela(i, vetordata);

                                teclaData = Console.ReadKey(true);
                                vetortecla = teclaData.Key.ToString().ToCharArray();

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

                                AtualizarTela(i, vetordata);
                            }

                            if (encontrado == true)
                            {

                                //"02021992"
                                if (DateTime.Compare(DateConverter(DataNascimento), System.DateTime.Now) < 0)
                                {
                                    string anonasc = (vetordata[4].ToString() + vetordata[5].ToString() + vetordata[6].ToString() + vetordata[7].ToString());
                                    DateTime anoantigo = System.DateTime.Now.AddYears(-120);
                                    if (int.Parse(anonasc) > int.Parse(anoantigo.Year.ToString()))
                                    {
                                        return DataNascimento;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Esse valor de data é muito antigo para cadastro!");
                                        retornar = PausaMensagem();
                                    }
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




                //case "dataabertura":
                //case "idaeronave":
                //case "capacidade":
                //case "situacao":
                //case "destino":
                //case "aeronave":
                //case "datavoo":
                //case "valorpassagem":

                default: return null;



            }
        }


        #region TELAS
        static void TelaInicial() // INCOMPLETO 
        {
            int opc;
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
                Console.Write("\nOpção: ");
                opc = int.Parse(Console.ReadLine()); // opc = int.Parse(ValidarEntrada("menu"));

                switch (opc)
                {
                    case 0:

                        // Lembrar de colocar uma chamada para todas funções de salvar antes.
                        Console.WriteLine("Encerrando...");
                        Environment.Exit(0); //Fecha o programa 

                        break;

                    case 1:

                        // Chamar a tela de Companhias Aereas

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

                        break;

                    case 5:

                        // Chamar a tela para ver os CNPJ's Restritos

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
                Console.Write("\nOpção: ");
                opc = int.Parse(Console.ReadLine()); // opc = int.Parse(ValidarEntrada("menu"));

                switch (opc)
                {
                    case 0:

                        // volta para tela inicial
                        TelaInicial();

                        break;

                    case 1:

                        // chamar a tela para validar entrada com CPF
                        TelaLoginPassageiro();

                        break;

                    case 2:

                        // chamar a tela para cadastrar passageiro
                        TelaCadastrarPassageiro();

                        break;
                }

            } while (opc != 0);
        }

        static void TelaLoginPassageiro() // OK ~ Falta Acertar o uso das funções e liberar as partes comentadas * 
        {
            //Passageiro passageiroAtivo;
            do
            {
                Console.Clear();
                Console.WriteLine("\nInforme o 'CPF' para Entrar:\n");
                //passageiroAtivo = ValidarLoginPassageiro();
                //if (passageiroAtivo == null)
                //  {
                //      Pausa();
                //      TelaInicialPassageiro();
                //  }

                TelaOpcoesPassageiro(/*passageiroAtivo*/); // encontrou um 'CPF' valido e existente nos cadastros, então manda para a tela de opções.


            } while (true);
        }

        static void TelaOpcoesPassageiro(/*Passageiro passageiroAtivo*/) // OK ~ Falta Acertar o uso das funções e liberar as partes comentadas * 
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
                Console.Write("\nOpção: ");
                opc = int.Parse(Console.ReadLine()); // opc = ValidarEntrada("menu");

                switch (opc)
                {
                    case 0:

                        TelaInicialPassageiros(); // escolheu sair, volta para a tela inicial de passageiros

                        break;

                    case 1:

                        TelaEditarPassageiro(/*Passageiro passageiroAtivo*/); // abre os dados do passageiro em questão para escolher quais quer editar

                        break;

                    case 2:

                        //bool restrito = false;
                        //bool maiorDe18 = false;
                        //string cpf = passageiroAtivo.Cpf;
                        //DateTime nascimento = passageiroAtivo.DataNascimento;

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

        static void TelaCadastrarPassageiro() // OK ~ Falta Acertar o uso das funções e liberar as partes comentadas * 
        {
            do
            {
                // variaveis locais
                string nome, cpf;
                string dataNascimento;
                char sexo;
            
                // Passageiro novoPassageiro;
               
                Console.Clear();
               
                nome = ValidarEntrada("nome");
                if (nome == null) TelaInicialPassageiros();

                cpf = ValidarEntrada("cpf");   /// OBS: Precisa validar se o 'CPF' já existe na lista de cadastros!
                if (cpf == null) TelaInicialPassageiros();

                dataNascimento = ValidarEntrada("datanascimento");
                if (dataNascimento == null) TelaInicialPassageiros();
                
                sexo = char.Parse(ValidarEntrada("sexo"));
                if (sexo.Equals(null)) TelaInicialPassageiros();

                Console.WriteLine("\nPassageiro Cadastrado com Sucesso!");
                Passageiro passageiro = new Passageiro(cpf, nome, DateConverter(dataNascimento), sexo,System.DateTime.Now,System.DateTime.Now,'A');
                listPassageiro.Add(passageiro);
                GravarPassageiro(listPassageiro);
                Pausa();
                TelaInicialPassageiros();

            } while (true);
        }

        static void TelaEditarPassageiro(/*Passageiro passageiroAtivo*/) // INCOMPLETO 
        {
            int opc;
            string novoNome;
            DateTime novaDataNascimento;
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
                Console.Write("\n 0 - VOLTAR");
                opc = int.Parse(Console.ReadLine()); // opc = int.Parse(ValidarEntrada("menu"));

                switch (opc)
                {
                    case 0:

                        TelaOpcoesPassageiro(/*Passageiro passageiroAtivo*/);

                        break;

                    case 1:

                        Console.Clear();
                        Console.WriteLine("\nNome Atual: " /* + passageiroAtivo.Nome*/);
                        Console.Write("\n\nInforme o Novo Nome: ");
                        //novoNome = ValidarEntrada("nome");
                        //if (novoNome == null) TelaEditarPassageiro(passageiroAtivo);

                        //passageiroAtivo.Nome = novoNome;
                        Console.WriteLine("\nNome Alterado com Sucesso!");
                        Pausa();
                        TelaEditarPassageiro(/*passageiroAtivo*/);

                        break;

                    case 2:

                        Console.Clear();
                        Console.WriteLine("\nData de nascimento Atual: "/* + passageiroAtivo.DataNascimento.ToShortDateString()*/);
                        Console.Write("\n\nInforme a Nova Data de Nascimento: ");
                        //novaDataNascimento = DateTime.Parse(ValidarEntrada("datanascimento"));
                        //if (novaDataNascimento == null) TelaEditarPassageiro(passageiroAtivo);

                        //passageiroAtivo.DataNascimento = novaDataNascimento;
                        Console.WriteLine("\nData de Nascimento Alterada com Sucesso!");
                        Pausa();
                        TelaEditarPassageiro(/*passageiroAtivo*/);

                        break;

                    case 3:

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("\nSexo Atual: " /* + passageiroAtivo.Sexo*/);
                            Console.Write("\n\nInforme o Novo Sexo: ");
                            Console.Write("\n [ F ] - Feminino");
                            Console.Write("\n [ M ] - Masculino");
                            Console.Write("\n [ N ] - Não informar");
                            Console.Write("\nOpção: ");
                            //novoSexo = char.Parse(ValidarEntrada("sexo"));
                            //if (novoSexo.Equals(null)) TelaInicialPassageiros();

                            //passageiroAtivo.Sexo = novoSexo;
                            Console.WriteLine("\nSexo Alterado com Sucesso!");
                            Pausa();
                            TelaEditarPassageiro(/*passageiroAtivo*/);
                        } while (true);

                    case 4:

                        Console.Clear();
                        Console.WriteLine("\nPASSAGEIRO: " /*passageiroAtivo.Nome*/);
                        //if (passageiroAtual.Situacao == 'A')
                        { Console.WriteLine("\nSituação Atual: ATIVO"); }
                        //if (passageiroAtual.Situacao == 'I')
                        { Console.WriteLine("\nSituação Atual: INATIVO"); }

                        //novaSituacao = char.Parse(ValidarEntrada("situacao"));
                        //if (novaSituacao.Equals(null)) TelaInicialPassageiros();

                        //passageiroAtivo.Situacao = novaSituacao;
                        Console.WriteLine("\nSexo Alterado com Sucesso!");
                        Pausa();
                        TelaEditarPassageiro(/*passageiroAtivo*/);
                        break;
                }

            } while (true);
        }

        #endregion

        #endregion

        static void Pausa() // OK 
        {
            Console.WriteLine("\nAperte 'ENTER' para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            System.IO.Directory.CreateDirectory(@"C:\DBOnTheFly");
            TelaInicial();
        }
    }
}

