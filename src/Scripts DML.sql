-- Criação da tabela 'brand'
CREATE TABLE brand (
    id UUID PRIMARY KEY CONSTRAINT pk_brand_id,
    name VARCHAR(255) NOT NULL,
    created_at TIMESTAMP WITH TIME ZONE NOT NULL,
    updated_at TIMESTAMP WITH TIME ZONE
);

-- Criação da tabela 'category'
CREATE TABLE category (
    id UUID PRIMARY KEY CONSTRAINT pk_category_id,
    name VARCHAR(255) NOT NULL,
    created_at TIMESTAMP WITH TIME ZONE NOT NULL,
    updated_at TIMESTAMP WITH TIME ZONE
);

-- Criação da tabela 'product'
CREATE TABLE product (
    id UUID PRIMARY KEY CONSTRAINT pk_product_id,
    name VARCHAR(255) NOT NULL,
    description VARCHAR(255),
    sku VARCHAR(255) UNIQUE NOT NULL,
    quantity BIGINT,
    brand_id UUID,
    category_id UUID,
    created_at TIMESTAMP WITH TIME ZONE NOT NULL,
    updated_at TIMESTAMP WITH TIME ZONE,
    CONSTRAINT pk_brand FOREIGN KEY (brand_id) REFERENCES brand(id) ON DELETE CASCADE,
    CONSTRAINT pk_category FOREIGN KEY (category_id) REFERENCES category(id) ON DELETE CASCADE
);

-- Criação de índice UNIQUE para a coluna 'sku' na tabela 'product'
CREATE UNIQUE INDEX idx_product_sku ON product(sku);
