CREATE TABLE task (
id INTEGER PRIMARY KEY, 
title TEXT, 
is_done BIT DEFAULT 0, 
created_at DATETIME
); 

INSERT INTO task (title, created_at) 
VALUES 
('Faire les courses', '2025-04-18'),
('Nettoyer l’appartement', '2025-04-18'),
('Aller à la salle de sport', '2025-04-18'),
('Appeler maman', '2025-04-18'),
('Lire 20 pages d’un livre', '2025-04-18'),
('Réviser le code Ruby', '2025-04-18');