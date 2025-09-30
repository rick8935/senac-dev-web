﻿using MeuCorre.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Domain.Entities
{
    public class Conta : Entidade
    {
        public required string Nome { get; set; }
        public required TipoConta Tipo { get; set; }
        public required decimal Saldo { get; set; }
        public required Guid UsuarioId { get; set; }
        public required bool Ativo { get; set; }
        public decimal? Limite { get; set; }
        public DateTime? DiaFechamento { get; set; }
        public DateTime? DiaVencimento { get; set; }
        public string? Cor { get; set; }
        public string? Icone { get; set; }

        public virtual Usuario Usuario { get; private set; }

        public string EhCartaoCredito(bool ehCartao)
        {
            if(ehCartao == true)
            {
                return "É cartão de crédito";
            }
            else
            {
                return "Não é cartão de crédito";
            }
        }

        public string EhCarteira(bool ehCarteira)
        {
            if (ehCarteira == true)
            {
                return "É carteira";
            }
            else
            {
                return "Não é carteira";
            }
        }

        public decimal CalcularLimiteDisponivel()
        {
            var limite = Limite;
            var saldo = Saldo;

            var limiteDisponivel = (limite.Value - saldo);
            return limiteDisponivel;
        }

        public string PodeFazerDebito(decimal valor, decimal saldo)
        {
            if(saldo >= valor)
            {
                return "Pode fazer o débito";
            }
            else
            {
                return "Não tem o saldo necessário";
            }
        }
    }
}
