-- Inserção de 20 pessoas
INSERT INTO PESSOA (Cpf, Nome, DataNascimento, EstaAtivo) VALUES ('12345678901', 'Carlos Silva', TO_DATE('1985-06-15', 'YYYY-MM-DD'), 'S');
INSERT INTO PESSOA (Cpf, Nome, DataNascimento, EstaAtivo) VALUES ('23456789012', 'Maria Oliveira', TO_DATE('1990-02-20', 'YYYY-MM-DD'), 'S');
INSERT INTO PESSOA (Cpf, Nome, DataNascimento, EstaAtivo) VALUES ('34567890123', 'João Souza', TO_DATE('1978-10-30', 'YYYY-MM-DD'), 'N');
INSERT INTO PESSOA (Cpf, Nome, DataNascimento, EstaAtivo) VALUES ('45678901234', 'Ana Costa', TO_DATE('1995-07-12', 'YYYY-MM-DD'), 'S');
INSERT INTO PESSOA (Cpf, Nome, DataNascimento, EstaAtivo) VALUES ('56789012345', 'Bruno Pereira', TO_DATE('1983-03-25', 'YYYY-MM-DD'), 'S');
INSERT INTO PESSOA (Cpf, Nome, DataNascimento, EstaAtivo) VALUES ('67890123456', 'Fernanda Lima', TO_DATE('2000-11-10', 'YYYY-MM-DD'), 'N');
INSERT INTO PESSOA (Cpf, Nome, DataNascimento, EstaAtivo) VALUES ('78901234567', 'Ricardo Almeida', TO_DATE('1970-01-01', 'YYYY-MM-DD'), 'S');
INSERT INTO PESSOA (Cpf, Nome, DataNascimento, EstaAtivo) VALUES ('89012345678', 'Patrícia Nunes', TO_DATE('1988-08-08', 'YYYY-MM-DD'), 'S');
INSERT INTO PESSOA (Cpf, Nome, DataNascimento, EstaAtivo) VALUES ('90123456789', 'Thiago Ramos', TO_DATE('1992-09-15', 'YYYY-MM-DD'), 'N');
INSERT INTO PESSOA (Cpf, Nome, DataNascimento, EstaAtivo) VALUES ('01234567890', 'Juliana Rocha', TO_DATE('1981-05-05', 'YYYY-MM-DD'), 'S');
INSERT INTO PESSOA (Cpf, Nome, DataNascimento, EstaAtivo) VALUES ('11223344556', 'Pedro Martins', TO_DATE('2002-04-18', 'YYYY-MM-DD'), 'S');
INSERT INTO PESSOA (Cpf, Nome, DataNascimento, EstaAtivo) VALUES ('22334455667', 'Luciana Fernandes', TO_DATE('1999-12-01', 'YYYY-MM-DD'), 'N');
INSERT INTO PESSOA (Cpf, Nome, DataNascimento, EstaAtivo) VALUES ('33445566778', 'Gabriel Moreira', TO_DATE('1987-06-06', 'YYYY-MM-DD'), 'S');
INSERT INTO PESSOA (Cpf, Nome, DataNascimento, EstaAtivo) VALUES ('44556677889', 'Camila Ribeiro', TO_DATE('1993-03-03', 'YYYY-MM-DD'), 'S');
INSERT INTO PESSOA (Cpf, Nome, DataNascimento, EstaAtivo) VALUES ('55667788990', 'Rafael Azevedo', TO_DATE('1975-12-12', 'YYYY-MM-DD'), 'N');
INSERT INTO PESSOA (Cpf, Nome, DataNascimento, EstaAtivo) VALUES ('66778899001', 'Tatiane Barros', TO_DATE('2001-01-20', 'YYYY-MM-DD'), 'S');
INSERT INTO PESSOA (Cpf, Nome, DataNascimento, EstaAtivo) VALUES ('77889900112', 'Fábio Cunha', TO_DATE('1996-09-09', 'YYYY-MM-DD'), 'S');
INSERT INTO PESSOA (Cpf, Nome, DataNascimento, EstaAtivo) VALUES ('88990011223', 'Renata Teixeira', TO_DATE('1980-10-10', 'YYYY-MM-DD'), 'S');
INSERT INTO PESSOA (Cpf, Nome, DataNascimento, EstaAtivo) VALUES ('99001122334', 'Marcelo Dias', TO_DATE('1984-07-07', 'YYYY-MM-DD'), 'N');
INSERT INTO PESSOA (Cpf, Nome, DataNascimento, EstaAtivo) VALUES ('10111213141', 'Aline Monteiro', TO_DATE('1991-02-02', 'YYYY-MM-DD'), 'S');

-- Inserção de telefones
INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Celular', '11999990001', 1);
INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Residencial', '1130000001', 1);

INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Celular', '11999990002', 2);

INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Celular', '11999990003', 3);
INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Comercial', '1140000003', 3);

INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Celular', '11999990004', 4);

INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Celular', '11999990005', 5);
INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Residencial', '1130000005', 5);
INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Comercial', '1140000005', 5);

INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Celular', '11999990006', 6);

INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Celular', '11999990007', 7);

INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Celular', '11999990008', 8);
INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Residencial', '1130000008', 8);

INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Celular', '11999990009', 9);

INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Celular', '11999990010', 10);

INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Celular', '11999990011', 11);
INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Comercial', '1140000011', 11);

INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Celular', '11999990012', 12);

INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Celular', '11999990013', 13);
INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Residencial', '1130000013', 13);
INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Comercial', '1140000013', 13);

INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Celular', '11999990014', 14);

INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Celular', '11999990015', 15);

INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Celular', '11999990016', 16);

INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Celular', '11999990017', 17);
INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Comercial', '1140000017', 17);

INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Celular', '11999990018', 18);

INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Celular', '11999990019', 19);
INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Residencial', '1130000019', 19);

INSERT INTO TELEFONE (Tipo, Numero, PessoaId) VALUES ('Celular', '11999990020', 20);

