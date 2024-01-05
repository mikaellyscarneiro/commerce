-- ###################################################
-- Criação das funções para atualização de datas
-- ###################################################

-- Função para definir created_at e updated_at durante a inserção. Uma vez criado, será reaproveitado para todas as triggers.
CREATE OR REPLACE FUNCTION db_products.public.fn_set_created_at()
RETURNS TRIGGER AS $$
BEGIN
    NEW.created_at := CURRENT_TIMESTAMP;
    NEW.updated_at := NULL;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Função para atualizar updated_at durante a atualização. Uma vez criado, será reaproveitado para todas as triggers.
CREATE OR REPLACE FUNCTION db_products.public.fn_set_updated_at()
RETURNS TRIGGER AS $$
BEGIN
    NEW.created_at := OLD.created_at;
    NEW.updated_at := CURRENT_TIMESTAMP;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- ###################################################
-- Criação da tabela 'brand'
-- ###################################################
CREATE TABLE db_products.public.brand (
    id UUID CONSTRAINT pk_brand_id PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    created_at TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP WITH TIME ZONE
);

CREATE TRIGGER tg_brand_created_at
BEFORE INSERT ON db_products.public.brand
FOR EACH ROW EXECUTE FUNCTION fn_set_created_at();

CREATE TRIGGER tg_brand_updated_at
BEFORE UPDATE ON db_products.public.brand
FOR EACH ROW EXECUTE FUNCTION fn_set_updated_at();

-- ###################################################
-- Criação da tabela 'category'
-- ###################################################
CREATE TABLE db_products.public.category (
    id UUID CONSTRAINT pk_category_id PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    created_at TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP WITH TIME ZONE
);

CREATE TRIGGER tg_category_created_at
BEFORE INSERT ON db_products.public.category
FOR EACH ROW EXECUTE FUNCTION fn_set_created_at();

CREATE TRIGGER tg_category_updated_at
BEFORE UPDATE ON db_products.public.category
FOR EACH ROW EXECUTE FUNCTION fn_set_updated_at();

-- ###################################################
-- Criação da tabela 'product'
-- ###################################################
CREATE TABLE db_products.public.product (
    id UUID CONSTRAINT pk_product_id PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    description VARCHAR(255),
    sku VARCHAR(255) UNIQUE NOT NULL,
    quantity BIGINT,
    brand_id UUID,
    category_id UUID,
    created_at TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP WITH TIME ZONE,
    CONSTRAINT pk_brand FOREIGN KEY (brand_id) REFERENCES brand(id) ON DELETE CASCADE,
    CONSTRAINT pk_category FOREIGN KEY (category_id) REFERENCES category(id) ON DELETE CASCADE
);

CREATE TRIGGER tg_product_created_at
BEFORE INSERT ON db_products.public.product
FOR EACH ROW EXECUTE FUNCTION fn_set_created_at();

CREATE TRIGGER tg_product_updated_at
BEFORE UPDATE ON db_products.public.product
FOR EACH ROW EXECUTE FUNCTION fn_set_updated_at();

-- Criação de índice UNIQUE para a coluna 'sku' na tabela 'product'
CREATE UNIQUE INDEX idx_product_sku ON db_products.public.product(sku);