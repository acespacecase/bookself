class TagsController < ApplicationController

  def index
    @tags = Tag.all
  end

  def show
  end

  def new
    @tag = Tag.new(tag_params)
  end

  def edit
  end

  def create
  end

  def update
  end

  def destroy
  end

end
