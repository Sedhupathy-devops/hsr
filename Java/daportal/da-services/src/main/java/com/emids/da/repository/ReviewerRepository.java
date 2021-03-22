package com.emids.da.repository;

import com.emids.da.model.Reviewer;
import com.emids.da.repository.AbstractRepository;
import com.google.inject.persist.Transactional;

@Transactional
public class ReviewerRepository extends AbstractRepository<Reviewer> {

  @Override
  public Reviewer findById(Long id) {
    return find(Reviewer.class, id);
  }
}
