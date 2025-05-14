import React, { useEffect, useState } from "react";
import axios from "axios";
import "./App.css";

const API_URL = "https://localhost:7240/api/Pessoas";

function App() {
  const [pessoas, setPessoas] = useState([]);
  const [cpfBusca, setCpfBusca] = useState("");
  const [editando, setEditando] = useState(false);
  const [form, setForm] = useState({
    cpf: "",
    nome: "",
    dataNascimento: "",
    estaAtivo: "S",
    telefones: [{ tipo: "", numero: "" }],
  });

  const buscarTodas = async () => {
    const response = await axios.get(API_URL);
    setPessoas(response.data);
  };

  const buscarPorCpf = async () => {
    if (!cpfBusca) return;
    try {
      const response = await axios.get(`${API_URL}/${cpfBusca}`);
      setPessoas([response.data]);
    } catch (err) {
      alert("Pessoa não encontrada");
    }
  };

  const salvarPessoa = async () => {
    try {
      if (editando) {
        await axios.put(`${API_URL}/${form.cpf}`, form);
        alert("Pessoa atualizada!");
      } else {
        await axios.post(API_URL, form);
        alert("Pessoa cadastrada!");
      }
      setForm({
        cpf: "",
        nome: "",
        dataNascimento: "",
        estaAtivo: "S",
        telefones: [{ tipo: "", numero: "" }],
      });
      setEditando(false);
      buscarTodas();
    } catch (err) {
      alert("Erro ao salvar pessoa");
    }
  };

  const excluirPessoa = async (cpf) => {
    await axios.delete(`${API_URL}/${cpf}`);
    alert("Pessoa excluída!");
    buscarTodas();
  };

  const editarPessoa = (pessoa) => {
    setForm({
      cpf: pessoa.cpf,
      nome: pessoa.nome,
      dataNascimento: pessoa.dataNascimento.slice(0, 10),
      estaAtivo: pessoa.estaAtivo,
      telefones: pessoa.telefones,
    });
    setEditando(true);
  };

  useEffect(() => {
    buscarTodas();
  }, []);

  const handleChange = (e, index, campoTelefone) => {
    const { name, value } = e.target;
    if (campoTelefone !== undefined) {
      const telefonesAtualizados = [...form.telefones];
      telefonesAtualizados[index][campoTelefone] = value;
      setForm({ ...form, telefones: telefonesAtualizados });
    } else {
      setForm({ ...form, [name]: value });
    }
  };

  const adicionarTelefone = () => {
    setForm({
      ...form,
      telefones: [...form.telefones, { tipo: "", numero: "" }],
    });
  };

  return (
    <div className="max-w-6xl mx-auto p-6 font-sans">
      <h1 className="text-3xl font-bold text-center mb-6 text-zinc-600">
        Cadastro de Pessoas
      </h1>

      <div className="mb-6 flex gap-2 items-center">
        <input
          type="text"
          placeholder="Buscar por CPF"
          value={cpfBusca}
          onChange={(e) => setCpfBusca(e.target.value)}
          className="border border-gray-300 rounded px-3 py-2 w-64"
        />
        <button
          onClick={buscarPorCpf}
          className="bg-blue-600 hover:bg-blue-700 text-white px-4 py-2 rounded"
        >
          Buscar
        </button>
        <button
          onClick={buscarTodas}
          className="bg-gray-500 hover:bg-gray-600 text-white px-4 py-2 rounded"
        >
          Limpar
        </button>
      </div>

      <div className="mb-8 border border-gray-200 rounded p-4 shadow-md">
        <h2 className="text-xl font-semibold mb-4 text-zinc-600">
          {editando ? "Editar Pessoa" : "Nova Pessoa"}
        </h2>
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
          <input
            name="cpf"
            placeholder="CPF"
            value={form.cpf}
            onChange={handleChange}
            className="border p-2 rounded"
            disabled={editando}
          />
          <input
            name="nome"
            placeholder="Nome"
            value={form.nome}
            onChange={handleChange}
            className="border p-2 rounded"
          />
          <input
            name="dataNascimento"
            type="date"
            value={form.dataNascimento}
            onChange={handleChange}
            className="border p-2 rounded"
          />
          <select
            name="estaAtivo"
            value={form.estaAtivo}
            onChange={handleChange}
            className="border p-2 rounded"
          >
            <option value="S">Ativo</option>
            <option value="N">Inativo</option>
          </select>
        </div>

        <div className="mt-4">
          <label className="font-medium text-zinc-600">Telefones:</label>
          {form.telefones.map((tel, idx) => (
            <div key={idx} className="flex gap-2 mt-2">
              <input
                placeholder="Tipo"
                value={tel.tipo}
                onChange={(e) => handleChange(e, idx, "tipo")}
                className="border p-2 rounded w-1/2"
              />
              <input
                placeholder="Número"
                value={tel.numero}
                onChange={(e) => handleChange(e, idx, "numero")}
                className="border p-2 rounded w-1/2"
              />
            </div>
          ))}
          <button onClick={adicionarTelefone} className="text-blue-600 mt-2">
            + Adicionar Telefone
          </button>
        </div>

        <div className="mt-4 flex gap-2">
          <button
            onClick={salvarPessoa}
            className="bg-green-600 hover:bg-green-700 text-white px-4 py-2 rounded"
          >
            {editando ? "Atualizar" : "Salvar"}
          </button>
          {editando && (
            <button
              onClick={() => {
                setEditando(false);
                setForm({
                  cpf: "",
                  nome: "",
                  dataNascimento: "",
                  estaAtivo: "S",
                  telefones: [{ tipo: "", numero: "" }],
                });
              }}
              className="bg-yellow-500 hover:bg-yellow-600 text-white px-4 py-2 rounded"
            >
              Cancelar
            </button>
          )}
        </div>
      </div>

      <h2 className="text-xl font-semibold mb-4 text-zinc-600">
        Lista de Pessoas
      </h2>
      <div className="overflow-x-auto">
        <table className="table-auto min-w-full border border-gray-300">
          <thead className="bg-gray-100">
            <tr>
              <th className="border p-2 text-left text-zinc-600">CPF</th>
              <th className="border p-2 text-left text-zinc-600">Nome</th>
              <th className="border p-2 text-left text-zinc-600">Nascimento</th>
              <th className="border p-2 text-left text-zinc-600">Ativo</th>
              <th className="border p-2 text-left text-zinc-600">Telefones</th>
              <th className="border p-2 text-left text-zinc-600">Ações</th>
            </tr>
          </thead>
          <tbody>
            {pessoas.map((p) => (
              <tr key={p.cpf} className="hover:bg-gray-50">
                <td className="border p-2">{p.cpf}</td>
                <td className="border p-2">{p.nome}</td>
                <td className="border p-2">
                  {new Date(p.dataNascimento).toLocaleDateString()}
                </td>
                <td className="border p-2">{p.estaAtivo}</td>
                <td className="border p-2">
                  <ul className="text-sm">
                    {p.telefones.map((t, i) => (
                      <li key={i}>
                        {t.tipo}: {t.numero}
                      </li>
                    ))}
                  </ul>
                </td>
                <td className="border p-2">
                  <button
                    onClick={() => editarPessoa(p)}
                    className="text-blue-600 hover:underline mr-2"
                  >
                    Editar
                  </button>
                  <button
                    onClick={() => excluirPessoa(p.cpf)}
                    className="text-red-600 hover:underline"
                  >
                    Excluir
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}

export default App;
