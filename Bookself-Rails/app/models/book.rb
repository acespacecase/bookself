class Book < ApplicationRecord
  belongs_to :user
  belongs_to :unique_book
  has_many :tags
end
