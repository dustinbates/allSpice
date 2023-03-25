CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

-- SECTION recipes
CREATE TABLE recipes(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  title VARCHAR(255) NOT NULL COMMENT 'Recipe Name',
  instructions VARCHAR(5000) NOT NULL COMMENT 'Recipe Instructions',
  img VARCHAR(1000) NOT NULL COMMENT 'Recipe Image',
  category VARCHAR(255) NOT NULL COMMENT 'Recipe Category',
  creatorId VARCHAR(255) NOT NULL COMMENT 'Creator Id',

  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

DROP TABLE recipes;

INSERT INTO recipes
(title, instructions, img, category, creatorId)
VALUES
('Side of Fries', 'Cut up a potato into thin strips, place in boiling oil, wait a while, remove from oil, salt, enjoy.', 'https://media-cldnry.s-nbcnews.com/image/upload/newscms/2017_23/1220588/stock-french-fries-today-170610-tease-01.jpg', 'Sides', '6414d2061c38166fcc365e1d');

SELECT
recipes.*,
accounts.*
FROM recipes
JOIN accounts ON recipes.creatorId = accounts.id;


-- SECTION ingredients
CREATE TABLE ingredients(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255) NOT NULL COMMENT 'Ingredient Name',
  quantity VARCHAR(255) NOT NULL COMMENT 'Quantity of Ingredient',
  recipeId INT NOT NULL COMMENT 'Recipe Id',

  FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

DROP TABLE ingredients;

INSERT INTO ingredients
(name, quantity, recipeId)
VALUES
('potatoes', '2 whole', 1);
INSERT INTO ingredients
(name, quantity, recipeId)
VALUES
('vegetable oil', '1 quart', 1);
INSERT INTO ingredients
(name, quantity, recipeId)
VALUES
('salt', '2 tablespoons', 1);

SELECT
*
FROM ingredients ingr
JOIN recipes ON recipes.id = ingr.recipeId
WHERE recipeId = 1;

-- SECTION favorites
CREATE TABLE favorites(
  id VARCHAR(255) NOT NULL PRIMARY KEY,
  accountId VARCHAR(255) NOT NULL COMMENT 'Account Id',
  recipeId INT NOT NULL COMMENT 'Recipe Id',

  FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

DROP TABLE favorites;

