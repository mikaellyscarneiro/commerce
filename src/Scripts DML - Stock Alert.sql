-- ###################################################
-- Criação das funções para atualização de datas
-- ###################################################

-- Função para definir created_at e updated_at durante a inserção. Uma vez criado, será reaproveitado para todas as triggers.
CREATE OR REPLACE FUNCTION db_stock_alert.public.fn_set_created_at()
RETURNS TRIGGER AS $$
BEGIN
    NEW.created_at := CURRENT_TIMESTAMP;
    NEW.updated_at := NULL;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Função para atualizar updated_at durante a atualização. Uma vez criado, será reaproveitado para todas as triggers.
CREATE OR REPLACE FUNCTION db_stock_alert.public.fn_set_updated_at()
RETURNS TRIGGER AS $$
BEGIN
    NEW.created_at := OLD.created_at;
    NEW.updated_at := CURRENT_TIMESTAMP;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- ###################################################
-- Criação da tabela 'stock_alert'
-- ###################################################
CREATE TABLE db_stock_alert.public.stock_alert (
    id UUID CONSTRAINT pk_stock_alert_id PRIMARY KEY,
    product_id UUID NOT NULL,
    quantity BIGINT NOT NULL,
    email VARCHAR(255) NOT NULL,
    is_deleted BOOLEAN NOT NULL,
    created_at TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP WITH TIME ZONE,
    deleted_at TIMESTAMP WITH TIME ZONE
);

CREATE TRIGGER tg_stock_alert_created_at
BEFORE INSERT ON db_stock_alert.public.stock_alert
FOR EACH ROW EXECUTE FUNCTION fn_set_created_at();

CREATE TRIGGER tg_stock_alert_updated_at
BEFORE UPDATE ON db_stock_alert.public.stock_alert
FOR EACH ROW EXECUTE FUNCTION fn_set_updated_at();