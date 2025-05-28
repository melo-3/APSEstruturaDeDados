# Simulação de Atendimento Médico com Estrutura de Dados

## Desafio Prático – Estrutura de Dados

**Grupo:** Eduardo Paes, Giovanna de Melo, Mariana Alves  

---

## Descrição

Este projeto simula o atendimento de pacientes em um sistema de saúde, aplicando conceitos fundamentais de estruturas de dados, como arrays, listas, pilhas e filas em C#. O objetivo é demonstrar, de forma prática e didática, como essas estruturas podem ser utilizadas para organizar e priorizar o atendimento, tornando-o mais eficiente e realista.

---

## Cenário Proposto

O sistema representa o fluxo de atendimento de pacientes, desde a chegada até o atendimento clínico, passando pela triagem e classificação de prioridade. Cada etapa utiliza estruturas de dados apropriadas para gerenciar e processar os pacientes.

### Etapas do Atendimento

1. **Chegada do Paciente:**  
   O paciente chega e entra em uma fila de triagem.

2. **Triagem:**  
   São coletados dados clínicos:
   - Pressão arterial
   - Temperatura corporal
   - Nível de oxigenação

3. **Classificação de Prioridade:**  
   Com base nos dados, o paciente recebe uma pulseira de prioridade:
   - **Vermelha (Prioridade Máxima):** pressão arterial > 18, temperatura > 39°C ou oxigenação < 90%
   - **Amarela (Prioridade Média):** pressão arterial > 14, temperatura > 37.5°C ou oxigenação < 95%
   - **Verde (Prioridade Normal):** demais casos

4. **Atendimento Clínico:**  
   Pacientes são atendidos em ordem de prioridade: vermelha, amarela e, por fim, verde.

---

## Estruturas de Dados Utilizadas

- **Filas (`Queue`)** para triagem e para gerenciar o atendimento de cada prioridade.
- **Array/Listas** para armazenamento das informações dos pacientes.
- **Pilha (`Stack`)** para histórico dos pacientes já atendidos.
- (Opcional) **Matriz** para armazenar dados clínicos dos pacientes.

---

## Organização do Código

O projeto está organizado em classes:

- **Paciente:**  
  Armazena informações do paciente e sua prioridade.

- **Triagem:**  
  Responsável por classificar o paciente conforme os dados clínicos.

- **SistemaAtendimento:**  
  Gerencia o fluxo de pacientes, da chegada ao histórico de atendimentos.

- **Program:**  
  Classe principal com o menu de cadastro e execução do sistema.

---

## Como Executar

1. Clone este repositório.
2. Abra o projeto em um ambiente compatível com C# (.NET).
3. Compile e execute o programa.
4. Siga as instruções no terminal para cadastrar pacientes e acompanhar o fluxo de atendimento.

---

## Exemplo de Funcionamento

```plaintext
=== SIMULAÇÃO DE ATENDIMENTO MÉDICO ===
Quantos pacientes deseja cadastrar? 3

--- Cadastro do 1º paciente ---
Nome: João
Pressão arterial (ex: 18.5): 19
Temperatura corporal (°C): 37
Nível de oxigenação (%): 95

...

--- Triagem ---
João | PA: 19 | Temp: 37°C | O2: 95% | Prioridade: Vermelha

--- Atendimento Clínico ---
Atendendo: João | PA: 19 | Temp: 37°C | O2: 95% | Prioridade: Vermelha

--- Histórico de Atendimentos ---
João foi atendido - Prioridade: Vermelha
```

---

## Recomendações e Diferenciais

- O sistema utiliza **cores no terminal** para indicar a prioridade do paciente (vermelho, amarelo e verde).
- O código é totalmente orientado a objetos e modularizado.
- O histórico de atendimentos é apresentado ao final, utilizando pilha.
- Fácil de expandir para interface gráfica ou integração com banco de dados.

---

## Objetivo Final

Demonstrar, por meio de uma simulação realista, como o uso adequado das estruturas de dados contribui para a organização, priorização e eficiência no atendimento de pacientes em sistemas de saúde.

---

## Licença

Este projeto é apenas para fins acadêmicos/didáticos.
