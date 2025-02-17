﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimeiroTrabalho
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

		protected void cv_Cpf_ServerValidate(object source, ServerValidateEventArgs args)
		{
			String cpf = args.Value;
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				args.IsValid = false;
			else
			{
				tempCpf = cpf.Substring(0, 9);
				soma = 0;

				for (int i = 0; i < 9; i++)
					soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
				resto = soma % 11;
				if (resto < 2)
					resto = 0;
				else
					resto = 11 - resto;
				digito = resto.ToString();
				tempCpf = tempCpf + digito;
				soma = 0;
				for (int i = 0; i < 10; i++)
					soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
				resto = soma % 11;
				if (resto < 2)
					resto = 0;
				else
					resto = 11 - resto;
				digito = digito + resto.ToString();
				args.IsValid = cpf.EndsWith(digito);
			}
		}

        protected void cv_DataNascimento_ServerValidate(object source, ServerValidateEventArgs args)
        {
			if(DateTime.Parse(args.Value) > DateTime.Now)
            {
				args.IsValid = false;
            }
			else
            {
				args.IsValid = true;
            }
        }

        protected void cv_Vacina_ServerValidate(object source, ServerValidateEventArgs args)
        {
			if(args.Value.Equals("... Selecione"))
            {
				args.IsValid = false;
            }
            else
            {
				args.IsValid = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}