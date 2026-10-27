-- Import into the existing application database. InnoDB is required for quotas/locking.
CREATE TABLE IF NOT EXISTS chatbot_sessions (
  token_hash CHAR(64) PRIMARY KEY,
  user_id VARCHAR(128) NOT NULL,
  expires_at DATETIME NOT NULL,
  INDEX (expires_at)
) ENGINE=InnoDB;
CREATE TABLE IF NOT EXISTS chatbot_usage (
  bucket VARCHAR(160) PRIMARY KEY,
  attempts INT NOT NULL DEFAULT 0,
  expires_at DATETIME NOT NULL,
  INDEX (expires_at)
) ENGINE=InnoDB;
CREATE TABLE IF NOT EXISTS chatbot_requests (
  request_id CHAR(36) PRIMARY KEY,
  owner_hash CHAR(64) NOT NULL,
  fingerprint CHAR(64) NOT NULL,
  response MEDIUMTEXT NULL,
  expires_at DATETIME NOT NULL,
  INDEX (expires_at)
) ENGINE=InnoDB;
CREATE TABLE IF NOT EXISTS chatbot_conversations (
  conversation_id CHAR(32) PRIMARY KEY,
  owner_hash CHAR(64) NOT NULL,
  context_id VARCHAR(64) NOT NULL,
  messages MEDIUMTEXT NOT NULL,
  expires_at DATETIME NOT NULL,
  INDEX (expires_at)
) ENGINE=InnoDB;
